using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movement;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveX = joystick.Horizontal;
        float moveZ = joystick.Vertical;
        movement = new Vector3(moveX,0, moveZ).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
