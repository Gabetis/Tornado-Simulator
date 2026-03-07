using UnityEngine;
using System.Collections.Generic;

public class PlayerZone : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectInRange;
    private void OnTriggerEnter(Collider other)
    {
        PullObject(other.gameObject);
    }

    private void PullObject(GameObject gameObject)
    {
        objectInRange.Add(gameObject);

    }
}
