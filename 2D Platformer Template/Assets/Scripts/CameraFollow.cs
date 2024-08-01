using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player transform to follow
    public Vector3 offset = new Vector3(0, 0, -10); // Offset between the player and the camera
    public float smoothSpeed = 0.125f; // Smoothing speed for the camera movement

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired position of the camera
            Vector3 desiredPosition = player.position + offset;

            // Smoothed position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;
        }
    }
}
