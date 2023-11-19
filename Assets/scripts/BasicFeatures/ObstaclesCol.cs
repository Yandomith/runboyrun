using UnityEngine;

public class ObstaclesCol : MonoBehaviour
{
    public GameObject Char;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Hit");
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<PlayerMove.SwipePlayerActions>().enabled = false;
            this.GetComponent<JumpAndDuckScript>().enabled = false;
            Debug.Log("Animation changed");
            Char.GetComponent<Animator>().Play("highitFall"); 
        }
    }

}
