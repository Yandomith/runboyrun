using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {   
        this.gameObject.GetComponent<BoxCollider>().enabled=false;
        thePlayer.GetComponent<SwipePlayerMove>().enabled= false;
    }
}
