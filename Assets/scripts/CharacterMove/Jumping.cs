using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpHeight = 2.0f; // Height to jump
    private float initialPositionY;
    private bool isJumping = false;
    private bool isReturning = false;

    void Start()
    {
        initialPositionY = transform.position.y;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && touch.deltaPosition.y > 0 && !isJumping && !isReturning)
            {
                // Swipe up (jump)
                Jump();
            }
        }

        if (isJumping)
        {
            PerformJump();
        }

        if (isReturning)
        {
            PerformReturn();
        }
    }

    void Jump()
    {
        isJumping = true;
    }

    void PerformJump()
    {
        float targetY = initialPositionY + jumpHeight;
        float currentY = transform.position.y;
        float step = Time.deltaTime * 6.0f; // Faster jump speed

        currentY = Mathf.MoveTowards(currentY, targetY, step);
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);

        if (currentY == targetY)
        {
            isJumping = false;
            isReturning = true;
        }
    }

    void PerformReturn()
    {
        float targetY = initialPositionY;
        float currentY = transform.position.y;
        float step = Time.deltaTime * 6.0f; // Faster return speed

        currentY = Mathf.MoveTowards(currentY, targetY, step);
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);

        if (currentY == targetY)
        {
            isReturning = false;
        }
    }
}
