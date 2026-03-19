using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public Vector3 offset;
    public Vector3 offsetRotation;
    private bool isShiftLockActive = false;

    private void Start()
    {
        Camera.main.transform.rotation = Quaternion.Euler(offsetRotation);
    }

    private void Update()
    {
        transform.position = playerTransform.position + offset; 
    }
}
