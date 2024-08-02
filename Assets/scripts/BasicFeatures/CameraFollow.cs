using UnityEngine;

public class CameraFollowHead : MonoBehaviour
{
    public Transform headTransform;    // The head's transform
    public float rotationSmoothing = 1f; // Smoothing factor for rotation

    private Quaternion initialRotation;

    private void Start()
    {
        // Calculate the initial rotation relative to the head
        initialRotation = Quaternion.Inverse(headTransform.rotation) * transform.rotation;
    }

    private void Update()
    {
         // Set the camera's position to match the parent object
        transform.position = headTransform.position;
        
        // Smoothly update the camera's rotation based on the head
        Quaternion targetRotation = headTransform.rotation * initialRotation;

        // Smoothly update the camera's rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing * Time.deltaTime);
        
       
    }
}
