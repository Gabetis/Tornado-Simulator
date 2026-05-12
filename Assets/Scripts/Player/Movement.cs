using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movement;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }
    void Update()
    {
        float moveX = joystick.Horizontal;
        float moveZ = joystick.Vertical;

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        movement = (camForward * moveZ + camRight * moveX).normalized;

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 10f);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
