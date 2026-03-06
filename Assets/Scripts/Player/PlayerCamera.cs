using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public Vector3 offset;
    private bool isShiftLockActive = false;

    private void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
