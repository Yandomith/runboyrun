using UnityEngine;
using PlayerMove;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject Player;
    public GameObject Char;

    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Hit");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            Player.GetComponent<PlayerMove.SwipePlayerActions>().enabled = false;
            Player.GetComponent<JumpAndDuckScript>().enabled = false;
            Debug.Log("Animation changed");
            Char.GetComponent<Animator>().Play("highitFall");
        }

    }
}
