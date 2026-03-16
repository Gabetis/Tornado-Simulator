using UnityEngine;
using System.Collections.Generic;

public class PlayerZone : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        if (playerManager == null)
        {
            playerManager = GetComponentInParent<PlayerManager>();
        }
    }
    private void Update()
    {
        var hits = Physics.OverlapSphere(transform.position, playerManager.Stats.suctionRadius, LayerMask.GetMask("PullAble"));

        foreach (var hit in hits)
        {
            hit.transform.position = Vector3.MoveTowards(hit.transform.position, transform.position, playerManager.Stats.Suction * Time.deltaTime);
        }
    }
}
