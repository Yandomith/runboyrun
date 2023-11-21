using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

   void OnTriggerEnter(Collider other)
   {
        
        this.gameObject.SetActive(false);
   }
}
