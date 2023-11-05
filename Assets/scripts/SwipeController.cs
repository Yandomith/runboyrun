using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Touch.PrimaryContact.started += OnStartTouch;
        playerControls.Touch.PrimaryContact.canceled += OnEndTouch;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Touch.PrimaryContact.started -= OnStartTouch;
        playerControls.Touch.PrimaryContact.canceled -= OnEndTouch;
    }

    private void OnStartTouch(InputAction.CallbackContext ctx)
    {
        touchStartPos = ctx.ReadValue<Vector2>();
        isSwiping = true;
    }

    private void OnEndTouch(InputAction.CallbackContext ctx)
    {
        isSwiping = false;
    }

    private void Update()
    {
        if (isSwiping)
        {
            Vector2 currentTouchPos = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
            Vector2 swipeDelta = currentTouchPos - touchStartPos;

            if (Mathf.Abs(swipeDelta.x) > 0.1f)
            {
                // Horizontal swipe detected
                float moveDirection = Mathf.Sign(swipeDelta.x);
                MovePlayer(moveDirection);
            }
        }
    }

    private void MovePlayer(float direction)
    {
        Vector3 movement = new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }
}
