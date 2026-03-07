using UnityEngine;

public class HitBoxZone : MonoBehaviour
{
    private Rigidbody rb;
    private Transform playerTransform;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerTransform = other.transform;
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position- transform.position).normalized;
            rb.MovePosition(transform.position + direction * Time.deltaTime);
        }
    }
}
