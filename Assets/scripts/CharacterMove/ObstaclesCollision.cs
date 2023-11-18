using UnityEngine;
using PlayerMove;

public class ObstaclesCollision : MonoBehaviour {
    public GameObject Player;
    public GameObject Char;


    void OnTriggerEnter (Collider other) 
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Hit");
        Player.GetComponent<PlayerMove.SwipePlayerActions>().enabled = false;
        Player.GetComponent<JumpAndDuckScript>().enabled = false;
        
        Char.GetComponent<Animator>().Play("highitFall");
        Debug.Log("Animation changed");

        if((Player.GetComponent<PlayerMove.SwipePlayerActions>().enabled == false) && (Player.GetComponent<JumpAndDuckScript>().enabled == false))
        {
            Char.GetComponent<Animator>().Play("highitFall");
            Debug.Log("Forced Animation changed ");
        }
    }
}
