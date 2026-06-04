using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public Vector3 offset;
    public Vector3 offsetRotation;

    [SerializeField] private float touchSensitivity = 0.2f;

    [SerializeField] private float zoomSensitivity = 0.05f;
    [SerializeField] private float minZoom = 0.2f;
    [SerializeField] private float maxZoom = 3f;
    private float currentZoom = 1f;

    private float currentYaw = 0f;

    private void Start()
    {
        currentYaw = playerTransform.eulerAngles.y;
        currentZoom = 1f;
    }

    private void Update()
    {
        HandleTouchInput();

        Vector3 rotatedOffset = Quaternion.Euler(0, currentYaw, 0) * (offset * currentZoom);

        transform.position = playerTransform.position + rotatedOffset;

        transform.LookAt(playerTransform.position);
    }

    private void HandleTouchInput()
    {
        // Zoom with two fingers on the right half of the screen
        if (Input.touchCount >= 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            bool canZoom = t0.position.x > Screen.width / 2f && t1.position.x > Screen.width / 2f;

            if (canZoom)
            {

                bool t0Moving = t0.phase == TouchPhase.Moved;
                bool t1Moving = t1.phase == TouchPhase.Moved;

                float prevDistance = Vector2.Distance(t0.position - t0.deltaPosition, t1.position - t1.deltaPosition);
                float currDistance = Vector2.Distance(t0.position, t1.position);
                float diff = prevDistance - currDistance;

                if (t0Moving && t1Moving && Mathf.Abs(diff) > 1f)
                {
                    currentZoom += diff * zoomSensitivity;
                    currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
                    return;
                }
            }
        }

        // Rotate with one finger on the right half of the screens  
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.position.x < Screen.width / 2f) continue;
            if (touch.phase != TouchPhase.Moved) continue;

            currentYaw += touch.deltaPosition.x * touchSensitivity;
        }
    }
}
