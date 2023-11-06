using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    public GameObject[] scene;
    public int zPos = 20;
    public bool creatingSection= false;
    public int secNum;
    public float GenerateTime = 1f;


    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());

        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0,3);
        Instantiate(scene[secNum],new Vector3(0,0,zPos), Quaternion.identity);
        yield return new WaitForSeconds(GenerateTime);
        
        creatingSection =false;


    }
}
