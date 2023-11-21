using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    public AudioSource CoinSFX;
   void OnTriggerEnter(Collider other)
   {
        CoinSFX.Play();
        this.gameObject.SetActive(false);
   }
}
