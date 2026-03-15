using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer != 3)
        {
            collision.gameObject.SetActive(false);
            playerManager.Stats.IncreaseCurrentSize(1);
        }
    }
}
