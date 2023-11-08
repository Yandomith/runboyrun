using UnityEngine;

public class CameraFollowHead : MonoBehaviour
{
    public Transform headTransform;    // The head's transform
    public float positionSmoothing = 10f; // Smoothing factor for position
    public float rotationSmoothing = 1f; // Smoothing factor for rotation

    private Vector3 initialOffset;
    private Quaternion initialRotation;

    private void Start()
    {
        // Calculate the initial offset and rotation relative to the head
        initialOffset = transform.position - headTransform.position;
        initialRotation = Quaternion.Inverse(headTransform.rotation) * transform.rotation;
    }

    private void Update()
    {
        // Smoothly update the camera's position and rotation based on the head
        Vector3 targetPosition = headTransform.position + initialOffset;
        Quaternion targetRotation = headTransform.rotation * initialRotation;

        transform.position = Vector3.Lerp(transform.position, targetPosition, positionSmoothing * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing * Time.deltaTime);
    }
}

