using System;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSuctionZone : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private ObjectData objectData;
    [SerializeField] private PullSystem pullSystem;

    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7) // 7 is PullAble layer
        {
            if (pullSystem.GetResultSuction(playerManager, collision.GetComponent<ObjectData>(), collision.GetComponent<ObjectData>().objectSO) == false)
            {
                return;
            }

            float EXP = pullSystem.GetEXP(collision.GetComponent<ObjectData>().objectSO, playerManager.Stats);
            playerManager.Stats.IncreaseCurrentSizeStore(EXP);

            GameEvent.UpdateRealScale();
            GameEvent.OnUpdateFill();
            GameEvent.UpdateSizeText((int)playerManager.Stats.currentSizeStore, playerManager.Stats.maxSize);
            GameEvent.RequestSound(SoundEvent.Suction);

            objectPooling = collision.gameObject.GetComponentInParent<ObjectPooling>();
            if (objectPooling != null)
                objectPooling.ReturnObject(collision.gameObject);
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
            objectData = hit.GetComponent<ObjectData>();

            if (pullSystem.GetResultSuction(playerManager, objectData, objectData.objectSO) == true)
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
}
