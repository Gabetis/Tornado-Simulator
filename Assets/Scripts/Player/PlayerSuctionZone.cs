using UnityEngine;
using System.Collections.Generic;
public class PlayerSuctionZone : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ObjectPooling objectPooling;

    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            playerManager.Stats.IncreaseCurrentSizeStore(1);
            GameEvent.UpdateRealScale();
            GameEvent.OnUpdateFill();
            GameEvent.UpdateSizeText(playerManager.Stats.currentSizeStore, playerManager.Stats.maxSize);
            objectPooling = collision.gameObject.GetComponentInParent<ObjectPooling>();
            if (objectPooling != null)
                objectPooling.ReturnObject(collision.gameObject);
            else
                Debug.Log("Cant find ObjectPooling");
        }
    }

    private void OnDrawGizmos()
    {
        if (playerManager == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerManager.Stats.suctionRadius);
    }

    private void Update()
    {
        var hits = Physics.OverlapSphere(transform.position, playerManager.Stats.suctionRadius, LayerMask.GetMask("PullAble"));

        foreach (var hit in hits)
        {
            Vector3 center = transform.position;
            Vector3 pos = hit.transform.position;

            Vector3 dir = (center - pos).normalized;

            Vector3 tangent = Vector3.Cross(dir, Vector3.up).normalized;

            float distance = Vector3.Distance(pos, center);
            float spin = Mathf.Clamp(1f / distance, 0.5f, 2f);

            Vector3 finalDir = (dir * 0.3f + tangent * spin).normalized;

            hit.transform.position += finalDir * playerManager.Stats.Suction * Time.deltaTime;
        }
    }
}
