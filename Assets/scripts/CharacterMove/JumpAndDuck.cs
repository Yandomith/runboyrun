using UnityEngine;

public class JumpAndDuck : MonoBehaviour
{
    public float jumpHeight = 2.0f; // Height to jump
    public float duckHeight = 1.0f; // Height to duck

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Ended:
                    if (touch.deltaPosition.y > 0)
                    {
                        // Swipe up (jump)
                        Jump();
                    }
                    else if (touch.deltaPosition.y < 0)
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
        // Perform jump action (e.g., animation, sound, etc.)
        Debug.Log("Jumping");
    }

    void Duck()
    {
        // Perform duck action (e.g., animation, sound, etc.)
        Debug.Log("Ducking");
    }
}
