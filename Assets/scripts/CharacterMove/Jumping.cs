using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpHeight = 2.0f; // Height to jump
    private float initialPositionY;
    private bool isJumping = false;

    void Start()
    {
        initialPositionY = transform.position.y;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && touch.deltaPosition.y > 0 && !isJumping)
            {
                // Swipe up (jump)
                Jump();
            }
        }
    }

    void Jump()
    {
        isJumping = true;
        float targetY = initialPositionY + jumpHeight;
        float currentY = transform.position.y;

        while (currentY < targetY)
        {
            currentY += Time.deltaTime * jumpHeight; // Adjust the jump speed here
            transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        }

        // Ensure the player reaches the exact target height
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

        // Return to the initial position
        while (currentY > initialPositionY)
        {
            currentY -= Time.deltaTime * jumpHeight; // Adjust the return speed here
            transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        }

        // Ensure the player returns to the initial position
        transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);

        isJumping = false;
    }
}
