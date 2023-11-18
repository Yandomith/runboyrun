using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {   
        this.gameObject.GetComponent<BoxCollider>().enabled=false;
        Player.GetComponent<SwipePlayerMove>().enabled= false;
    }
}
