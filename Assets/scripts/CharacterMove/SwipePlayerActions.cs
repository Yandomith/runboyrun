using UnityEngine;

namespace PlayerMove{
    public class SwipePlayerActions : MonoBehaviour
    {
        public float moveSpeed = 10f;
        private float currentPosition = 4.0f; // Initial player position
        private float moveDistance = 5.5f; // Fixed movement distance

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
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            StartCoroutine(IncreaseRunSpeed());

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        hasMoved = false;
                        break;

                    case TouchPhase.Moved:
                        if (!hasMoved)
                        {
                            float magnitude = touch.deltaPosition.magnitude;
                            float angle = Vector2.SignedAngle(Vector2.right, touch.deltaPosition);
                            
                            if (magnitude >= swipeAngleThreshold)
                            {
                                if (angle < 0) angle += 360;
                                
                                if (angle >= minSwipeAngleRight && angle <= maxSwipeAngleRight)
                                    Move(1);
                                else if (angle >= minSwipeAngleLeft && angle <= maxSwipeAngleLeft)
                                    Move(-1);
                            }
                        }
                        break;
                }
            }
        }




        IEnumerator DestroyClone()
        {
            yield return new WaitForSeconds(60);
            moveSpeed = moveSpeed+5;


        }


        void Move(float direction)
        {
            float newPosition = currentPosition + (direction * moveDistance);
            newPosition = Mathf.Clamp(newPosition, boundaryLeft, boundaryRight);

            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
            currentPosition = newPosition;
            hasMoved = true;
        }
    }
}