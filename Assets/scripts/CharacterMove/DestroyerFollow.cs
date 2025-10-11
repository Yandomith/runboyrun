using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerFollow : MonoBehaviour
{

    [SerializeField] private Transform target; // The object to follow

    private void Update()
    {
        if (target != null)
        {
            // Get the current position of the target
            Vector3 targetPosition = target.position ;

            // Update the follower's position only along the Z-axis
            transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
        }
    }
}


