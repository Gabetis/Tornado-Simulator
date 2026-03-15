using UnityEngine;
using System.Collections.Generic;

public class PlayerZone : MonoBehaviour
{
    [SerializeField] private List<PullAble> pullAlbeObjectInRange;
    private PlayerManager playerManager;

    private void Start()
    {
        if(playerManager == null)
        {
            playerManager = GetComponentInParent<PlayerManager>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PullAble pullAble = other.GetComponent<PullAble>();
        if (pullAble != null) 
            pullAlbeObjectInRange.Add(pullAble);
    }
    
    private void OnTriggerExit(Collider other)
    {
        PullAble pullAble = other.GetComponent<PullAble>();
        if (pullAble != null) 
            pullAlbeObjectInRange.Remove(pullAble);
    }

    private void Update()
    {
        foreach (var obj in pullAlbeObjectInRange)
        {
            obj.PullTowards(transform.position, playerManager.Stats.Suction);
        }
    }
}
