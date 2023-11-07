using UnityEngine;

public class SwipePlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentPosition = 4.0f; // Initial player position
    private float moveDistance = 5.5f; // Fixed movement distance

    private float boundaryLeft = -1.5f; // Minimum allowed position
    private float boundaryRight = 9.5f; // Maximum allowed position
    private bool hasMoved = false; // Flag to track if the player has moved in the current swipe

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Reset the flag at the beginning of each swipe
                    hasMoved = false;
                    break;

                case TouchPhase.Moved:
                    if (!hasMoved)
                    {
                        // Calculate the swipe direction
                        float direction = Mathf.Sign(touch.deltaPosition.x);

                        // Calculate the new position based on the direction and fixed distance
                        float newPosition = currentPosition + (direction * moveDistance);

                        // Ensure the player stays within the boundaries
                        newPosition = Mathf.Clamp(newPosition, boundaryLeft, boundaryRight);

                        // Update the player's position and set the flag to indicate movement
                        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
                        currentPosition = newPosition;
                        hasMoved = true;
                    }
                    break;
            }
        }
    }
}
