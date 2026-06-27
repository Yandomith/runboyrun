using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Destroy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        // Destroy(gameObject);
        StartCoroutine(DestroyAfterDelay());

    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(60f); // Wait for 60 seconds
        Destroy(gameObject);
    }

}

