using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMove : MonoBehaviour
{

     public float moveSpeed = 8f;

       void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
       
    }
}
