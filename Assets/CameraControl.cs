using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // Player
    public Transform cameraTransform; // The actual camera (child of this object)
    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed = 3f;
    public float pitchMin = -20f;
    public float pitchMax = 60f;
    public float collisionRadius = 0.3f;
    public LayerMask collisionLayers;

    private float yaw = 0f;
    private float pitch = 15f;

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
        }

        // Desired rotation and direction
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 targetOffset = target.position + Vector3.up * height;
        Vector3 desiredPosition = targetOffset + rotation * new Vector3(0, 0, -distance);

        // Raycast to check for obstacles
        RaycastHit hit;
        Vector3 direction = desiredPosition - targetOffset;
        float adjustedDistance = distance;

        if (Physics.SphereCast(targetOffset, collisionRadius, direction.normalized, out hit, distance, collisionLayers))
        {
            adjustedDistance = hit.distance - 0.1f; // Pull camera slightly before the obstacle
        }

        // Final camera position and look
        Vector3 finalPosition = targetOffset + rotation * new Vector3(0, 0, -adjustedDistance);
        cameraTransform.position = finalPosition;
        cameraTransform.LookAt(targetOffset);
    }
}
