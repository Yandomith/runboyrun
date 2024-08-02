using UnityEngine;
using PlayerMove;


public class ObstaclesCol : MonoBehaviour
{
    public GameObject Char;
    public GameObject LevelControlls;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Hit");
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<PlayerController>().enabled = false;
            LevelControlls.GetComponent<LevelDistance>().enabled =false;
            Debug.Log("Animation changed");
            Char.GetComponent<Animator>().Play("highitFall"); 
            LevelControlls.GetComponent<EndRunScreen>().enabled = true;

        }
    }

}
