using UnityEngine;

public class CrouchingScript : MonoBehaviour
{
    private Vector3 originalScale;
    private Transform pivot;

    private bool isCrouching = false;

    void Start()
    {
        // Get the original scale and find the pivot child.
        originalScale = transform.localScale;
        pivot = transform.GetChild(0); // Adjust the index if necessary.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Change this to your crouching input.
        {
            if (!isCrouching)
            {
                Debug.Log("Crouching");
                // Crouch (scale down along the Y-axis).
                transform.localScale = new Vector3(originalScale.x, originalScale.y / 2, originalScale.z);

                // Move the pivot child's position.
                pivot.localPosition = new Vector3(0, -originalScale.y / 4, 0);

                isCrouching = true;
            }
            else
            {
                Debug.Log("Standing up");
                // Stand up (restore original scale and pivot position).
                transform.localScale = originalScale;
                pivot.localPosition = Vector3.zero;

                isCrouching = false;
            }
        }
    }
}
