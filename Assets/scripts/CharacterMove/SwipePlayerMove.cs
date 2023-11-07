using UnityEngine;

public class SwipePlayerActions : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentPosition = 4.0f; // Initial player position
    private float moveDistance = 5.5f; // Fixed movement distance
    private float jumpHeight = 2.0f; // Height to jump
    private float duckHeight = 1.0f; // Height to duck

    private float boundaryLeft = -1.5f; // Minimum allowed position
    private float boundaryRight = 9.5f; // Maximum allowed position
    private bool hasMoved = false; // Flag to track if the player has moved in the current swipe

    public float swipeAngleThreshold = 30.0f; // Swipe angle threshold in degrees

    public float minSwipeAngleRight = 330.0f; // Minimum accepted swipe angle for right swipe
    public float maxSwipeAngleRight = 30.0f; // Maximum accepted swipe angle for right swipe
    public float minSwipeAngleLeft = 150.0f; // Minimum accepted swipe angle for left swipe
    public float maxSwipeAngleLeft = 210.0f; // Maximum accepted swipe angle for left swipe
    public float minSwipeAngleJump = 70.0f; // Minimum accepted swipe angle for jumping
    public float maxSwipeAngleJump = 110.0f; // Maximum accepted swipe angle for jumping
    public float minSwipeAngleDuck = 250.0f; // Minimum accepted swipe angle for ducking
    public float maxSwipeAngleDuck = 290.0f; // Maximum accepted swipe angle for ducking

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
                            else if (angle >= minSwipeAngleJump && angle <= maxSwipeAngleJump)
                            {
                                // Jumping swipe
                                Jump();
                                hasMoved = true;
                            }
                            else if (angle >= minSwipeAngleDuck && angle <= maxSwipeAngleDuck)
                            {
                                // Ducking swipe
                                Duck();
                                hasMoved = true;
                            }
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    // Detect swipe gestures based on vertical swipe distance
                    if (touch.deltaPosition.y > 0 && touch.deltaPosition.y > Mathf.Abs(touch.deltaPosition.x))
                    {
                        // Swipe up (jump)
                        Jump();
                    }
                    else if (touch.deltaPosition.y < 0 && Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x))
                    {
                        // Swipe down (duck)
                        Duck();
                    }
                    break;
            }
        }
    }

    void Jump()
    {
        // Move the player upwards for jumping
        Vector3 jumpTarget = transform.position + Vector3.up * jumpHeight;
        transform.position = new Vector3(transform.position.x, jumpTarget.y, transform.position.z);
    }

    void Duck()
    {
        // Move the player downwards for ducking
        Vector3 duckTarget = transform.position + Vector3.down * duckHeight;
        transform.position = new Vector3(transform.position.x, duckTarget.y, transform.position.z);
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
