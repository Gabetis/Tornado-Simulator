using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.SetActive(false);
            playerManager.Stats.IncreaseCurrentSizeStore(1);
            playerManager.transform.localScale = Vector3.one * (1 + playerManager.Stats.sizeMultiplier * playerManager.Stats.currentSize); //Increase real size
            GameEvent.OnUpdateFill();
            GameEvent.UpdateSizeText(playerManager.Stats.currentSizeStore, playerManager.Stats.maxSize);
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
