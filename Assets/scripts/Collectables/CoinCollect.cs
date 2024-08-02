using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

   void OnTriggerEnter(Collider other)
   {
        CollectableControlls.coinCount +=2;

        this.gameObject.SetActive(false);
   }
}
