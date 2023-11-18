using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Disable the collider of the current GameObject
            GetComponent<Collider>().enabled = false;

            // Disable the SwipePlayerMove script on the player GameObject
            player.GetComponent<UnityEngine.SwipePlayerMove>().enabled = false;
        }
    }
}
