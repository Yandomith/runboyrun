using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndDuckScript : MonoBehaviour
{
    public float minSwipeAngleJump = 70.0f; // Minimum accepted swipe angle for jumping
    public float maxSwipeAngleJump = 110.0f; // Maximum accepted swipe angle for jumping
    public float minSwipeAngleDuck = 250.0f; // Minimum accepted swipe angle for ducking
    public float maxSwipeAngleDuck = 290.0f; 

    public bool isJumping= false;
    public bool comingDown = false;
    public float jumpSpeed = 3f;

   

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
                        if (isJumping == false)
                        {
                            isJumping=true;
                            StartCoroutine(JumpSequence());

                        }
                    }
                    else if (angle >= minSwipeAngleDuck && angle <= maxSwipeAngleDuck)
                    {
                        Duck();
                    }
                    break;
            }
        }



        if (isJumping== true)
        {
            if(comingDown == false)
            {
                transform.Translate(Vector3.up* Time.deltaTime*3,Space.World);

            }
            if(comingDown == true)
            {
                transform.Translate(Vector3.up* Time.deltaTime*-3,Space.World);
                if(this.gameObject.transform.position.y != 2.5f )
                {
                    float newY = Mathf.Lerp(transform.position.y, 2.5f, jumpSpeed * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
                }
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;

    }

    void Duck()
    {
        // Handle ducking logic here...
    }

}
