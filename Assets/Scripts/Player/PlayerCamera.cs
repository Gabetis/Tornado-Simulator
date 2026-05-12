using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public Vector3 offset;
    public Vector3 offsetRotation;

    public float touchSensitivity = 0.2f;

    private float currentYaw = 0f;

    private void Start()
    {
        currentYaw = playerTransform.eulerAngles.y;
        //Camera.main.transform.rotation = Quaternion.Euler(offsetRotation);
    }

    private void Update()
    {
        HandleTouchInput();

        Vector3 rotatedOffset = Quaternion.Euler(0, currentYaw, 0) * offset;

        transform.position = playerTransform.position + rotatedOffset;

        transform.LookAt(playerTransform.position);
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    currentYaw += touch.deltaPosition.x * touchSensitivity;
                }
            }
        }
    }
}
