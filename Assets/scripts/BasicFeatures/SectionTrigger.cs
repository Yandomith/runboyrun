using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
 public GameObject[] Section;
 public int secNum;
 public int zPos = 20;

 private void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.CompareTag("GenerateWallTrigger"))
    {
        secNum = Random.Range(0,3);
        Instantiate(Section[secNum],new Vector3(0,0,zPos), Quaternion.identity);
          zPos +=20;    
    }
 }
}
