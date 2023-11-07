using UnityEngine;

public class JumpAndDuckScript : MonoBehaviour
{
    public float jumpSpeed = 10.0f; // Adjust this value to control the jump speed
    public float returnSpeed = 15.0f; // Adjust this value to control the return speed
    public float jumpHeight = 3.0f; // Height to jump
    public float duckHeight = 1.0f; // Height to duck

    private Vector3 initialPosition; // Store the initial position before jumping
    private bool isJumping; // Flag to track if the player is jumping
    private Vector3 jumpTarget; // Target position for jumping

    public float minSwipeAngleJump = 70.0f; // Minimum accepted swipe angle for jumping
    public float maxSwipeAngleJump = 110.0f; // Maximum accepted swipe angle for jumping
    public float minSwipeAngleDuck = 250.0f; // Minimum accepted swipe angle for ducking
    public float maxSwipeAngleDuck = 290.0f; // Maximum accepted swipe angle for ducking

    void Start()
    {
        // Store the initial position at the start of the game
        initialPosition = transform.position;
        isJumping = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Handle the beginning of the swipe...
                    break;

                case TouchPhase.Moved:
                    // Calculate the angle based on touch.deltaPosition...
                    float angle = Vector2.SignedAngle(Vector2.right, touch.deltaPosition);

                    // Check for swipe angles to trigger jump or duck...
                    if (angle >= minSwipeAngleJump && angle <= maxSwipeAngleJump)
                    {
                        Jump();
                    }
                    else if (angle >= minSwipeAngleDuck && angle <= maxSwipeAngleDuck)
                    {
                        Duck();
                    }
                    break;
            }
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            // Calculate the target position for jumping
            jumpTarget = transform.position + Vector3.up * jumpHeight;
            isJumping = true;
        }

        // If the player is below the jump target, move upward for jumping
        if (transform.position.y < jumpTarget.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpSpeed * Time.deltaTime, transform.position.z);
        }
        else
        {
            // Once the player has reached or surpassed the jump target, quickly return to the initial position
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

            // If the player has returned to the initial position, reset the jump flag
            if (transform.position == initialPosition)
            {
                isJumping = false;
            }
        }
    }

    public void Duck()
    {
        // Move the player downwards for ducking
        Vector3 duckTarget = transform.position + Vector3.down * duckHeight;
        transform.position = new Vector3(transform.position.x, duckTarget.y, transform.position.z);
    }
}
