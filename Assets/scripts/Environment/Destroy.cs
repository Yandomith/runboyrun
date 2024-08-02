using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Destroy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyWallTrigger"))
        {
            // Destroy(gameObject);
            StartCoroutine(DestroyAfterDelay());
        }
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForEndOfFrame(); // Waits until the end of the frame to avoid timing issues
        Debug.Log("Actually Destroying: " + gameObject.name);
        Destroy(gameObject);
    }
}

    