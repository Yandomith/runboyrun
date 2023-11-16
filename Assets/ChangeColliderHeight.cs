using UnityEngine;

public class ChangeColliderHeight : MonoBehaviour
{
    private BoxCollider boxCollider;
    public bool isJumping= false;
    public bool comingDown = false;
    public GameObject playerObject;

    void Start()
    {
        // Assuming the GameObject has a BoxCollider attached
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Example: Change the apparent height from the bottom
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            // Calculate the new Y component of the center to move the collider up
            float newYCenter = boxCollider.size.y / 2f;

            // Adjust the center to move the collider up
            boxCollider.center = new Vector3(boxCollider.center.x, newYCenter, boxCollider.center.z);

            // Optionally adjust the size accordingly if needed
            // boxCollider.size = new Vector3(boxCollider.size.x, newYCenter * 2f, boxCollider.size.z);
        }
    }
}
