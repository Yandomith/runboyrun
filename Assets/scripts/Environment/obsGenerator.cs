using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private int obstaclesProbability;
    private int randomizer;
    private int zPos = 140;
    private int[] xPositions = { 0, 6, -6 }; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GenerateWallTrigger"))
        {
            for (int i = 0; i < xPositions.Length; i++)
            {
                obstaclesProbability = Random.Range(0, 500);
                if (obstaclesProbability <= 200)
                {
                    randomizer = Random.Range(0, obstacles.Length);
                    Instantiate(obstacles[randomizer], new Vector3(xPositions[i], 0, zPos), Quaternion.identity);
                }
            }
        }
        zPos += 20;
    }
}
