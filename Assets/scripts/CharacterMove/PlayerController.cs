using PlayerMove;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControlls playerControlls;
    [SerializeField] private float moveDistance = 6f; // Distance to move per input
    [SerializeField] private float jumpSpeed = 7f;
    public float forwardSpeed = 7f; // Speed for forward movement
    [SerializeField] private float sideMoveSpeed = 30f; // Speed for side movement
    private Rigidbody rb;
    private Animator animator;
    private Collider col;
    [SerializeField] private GameObject model;
    [SerializeField] private LayerMask ground;

    private bool isMoving = false; // Flag to prevent multiple simultaneous movements
    private Vector3 targetPosition;

    // Boundaries for the x-axis
    private float minX = -6f;
    private float maxX = 6f;


    private void Awake()
    {
        playerControlls = new PlayerControlls();
        rb = GetComponent<Rigidbody>();
        animator = model.GetComponent<Animator>();
        col = GetComponent<Collider>();

        // Set the initial target position to the current position
        targetPosition = transform.position;
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }

    private void Start()
    {
        playerControlls.Land.Jump.performed += _ => StartJump();
        playerControlls.Land.Move.performed += ctx => StartMove(ctx.ReadValue<Vector2>());
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        // Move the player forward continuously
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);
        animator.SetBool("Run", true);
    }

    private void StartMove(Vector2 inputVector)
    {
        // Check if the input is valid and within boundaries
        if (inputVector != Vector2.zero && IsValidMovement(inputVector))
        {
            if (!isMoving)
            {
                StartCoroutine(MoveToPosition(inputVector));
            }
        }
    }

    private bool IsValidMovement(Vector2 inputVector)
    {
        // Calculate the potential new position
        Vector3 moveVector = new Vector3(inputVector.x, 0, 0) * moveDistance;
        Vector3 potentialTargetPosition = transform.position + moveVector;

        // Check if the potential position is within bounds
        return (potentialTargetPosition.x >= minX && potentialTargetPosition.x <= maxX);
    }

    private IEnumerator MoveToPosition(Vector2 inputVector)
    {
        isMoving = true;

        // Calculate the move distance based on input
        Vector3 moveVector = new Vector3(inputVector.x, 0, 0) * moveDistance;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + moveVector;

        float elapsedTime = 0;
        float journeyTime = moveDistance / sideMoveSpeed; // Adjust this for speed as needed

        while (elapsedTime < journeyTime)
        {
            // Lerp only on the x-axis while keeping the current y and z position
            transform.position = new Vector3(
                Mathf.Lerp(startPosition.x, targetPosition.x, (elapsedTime / journeyTime)),
                startPosition.y,
                startPosition.z
            );

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set correctly to 0, -6, or 6
        transform.position = new Vector3(SnapToValidPosition(transform.position.x), startPosition.y, startPosition.z);

        Debug.Log($"Input Vector: {inputVector}, Move Vector: {moveVector}");

        isMoving = false;
    }

    private float SnapToValidPosition(float x)
    {
        // Snap to -6, 0, or 6 based on the current x value
        if (x < -3) return -6f;
        else if (x > 3) return 6f;
        else return 0f;
    }

    private void StartJump()
    {
        if (CheckGrounded())
        {
            Debug.Log("Player is grounded, jumping...");
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
        else
        {
            Debug.Log("Player is not grounded, cannot jump.");
        }
    }

    private bool CheckGrounded()
    {
        Vector3 colliderCenter = col.bounds.center;
        Vector3 colliderSize = col.bounds.size;
        Vector3 halfExtents = colliderSize * 0.5f; // Half the size of the collider

        return Physics.CheckBox(colliderCenter, halfExtents, Quaternion.identity, ground);
    }
}

