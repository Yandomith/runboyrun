using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] TreesPrefabs;
    [SerializeField] private GameObject[] BuildingsPrefabs;
    [SerializeField]private int probability;
    private int PrefabNum;
    public GameObject[] Section;
    private int secNum;
    public int zPos = 20;
    private int randomRight;

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("GenerateWallTrigger"))
       {

            secNum = Random.Range(0,3);
            Instantiate(Section[secNum],new Vector3(0,0,zPos), Quaternion.identity);
            
            PrefabNum = Random.Range(0,probability);
            randomRight = Random.Range(0, 3);
            if(PrefabNum < 50)
            {
                Instantiate(BuildingsPrefabs[secNum],new Vector3(20,0,zPos),Quaternion.Euler(0, 180, 0)); 
                Instantiate(BuildingsPrefabs[randomRight], new Vector3(-20, 0, zPos), Quaternion.identity);
            }
            else
            {
                Instantiate(TreesPrefabs[secNum],new Vector3(20,0,zPos), Quaternion.Euler(0, 180, 0));
                Instantiate(TreesPrefabs[randomRight], new Vector3(-20, 0, zPos), Quaternion.identity);

            }
            zPos +=20;

        }
     }  
}
