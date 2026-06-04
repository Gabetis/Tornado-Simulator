using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private PlayerManager playerManager;

    private void Awake()
    {
        if(playerManager == null)
        {
            playerManager = GetComponentInParent<PlayerManager>();
        }
    }
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
        var movespeed = playerManager.Stats.currentMoveSpeed;
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }
}
