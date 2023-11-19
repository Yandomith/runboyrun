using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMove : MonoBehaviour
{

     // public GameObject LevelControls;
     public float moveSpeed = 8f;

       void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
     //     if (LevelControls.GetComponent<IsOut>().enabled == false)
     //     {
     //           this.gameObject.GetComponent<EnvironmentMove>().enabled = false;
     //     }
       
    }
}
