using UnityEngine;

public class SwipePlayerActions : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentPosition = 4.0f; // Initial player position
    private float moveDistance = 5.5f; // Fixed movement distance
    private float duckHeight = 1.0f; // Height to duck

    private float boundaryLeft = -1.5f; // Minimum allowed position
    private float boundaryRight = 9.5f; // Maximum allowed position
    private bool hasMoved = false; // Flag to track if the player has moved in the current swipe

    public float swipeAngleThreshold = 10.0f; // Reduced swipe angle threshold in degrees

    public float minSwipeAngleRight = 330.0f; // Minimum accepted swipe angle for right swipe
    public float maxSwipeAngleRight = 360.0f; // Maximum accepted swipe angle for right swipe
    public float minSwipeAngleLeft = 150.0f; // Minimum accepted swipe angle for left swipe
    public float maxSwipeAngleLeft = 210.0f; // Maximum accepted swipe angle for left swipe

    // Reference to the jumping and ducking script
    public JumpAndDuckScript jumpAndDuckScript;

    void Start()
    {
        // Initialize the reference to the jumping and ducking script
        jumpAndDuckScript = GetComponent<JumpAndDuckScript>();
    }

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
                        // Calculate the swipe direction based on the magnitude and angle
                        float magnitude = touch.deltaPosition.magnitude;
                        float angle = Vector2.SignedAngle(Vector2.right, touch.deltaPosition);

                        if (magnitude >= swipeAngleThreshold)
                        {
                            if (angle < 0)
                            {
                                angle += 360; // Ensure positive angle
                            }

                            if (angle >= minSwipeAngleRight && angle <= maxSwipeAngleRight)
                            {
                                // Right swipe
                                Move(1);
                                hasMoved = true;
                            }
                            else if (angle >= minSwipeAngleLeft && angle <= maxSwipeAngleLeft)
                            {
                                // Left swipe
                                Move(-1);
                                hasMoved = true;
                            }
                            else
                            {
                                // Call the jump or duck method from the separate script
                                if (angle >= jumpAndDuckScript.minSwipeAngleJump && angle <= jumpAndDuckScript.maxSwipeAngleJump)
                                {
                                    jumpAndDuckScript.Jump();
                                    hasMoved = true;
                                }
                                else if (angle >= jumpAndDuckScript.minSwipeAngleDuck && angle <= jumpAndDuckScript.maxSwipeAngleDuck)
                                {
                                    jumpAndDuckScript.Duck();
                                    hasMoved = true;
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }

    void Move(float direction)
    {
        // Calculate the new position based on the direction and fixed distance
        float newPosition = currentPosition + (direction * moveDistance);

        // Ensure the player stays within the boundaries
        newPosition = Mathf.Clamp(newPosition, boundaryLeft, boundaryRight);

        // Update the player's position and set the flag to indicate movement
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        currentPosition = newPosition;
        hasMoved = true;
    }
}
