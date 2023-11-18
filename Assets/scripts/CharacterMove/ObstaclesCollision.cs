using UnityEngine;
using PlayerMove;

public class ObstaclesCollision : MonoBehaviour {
    public GameObject Player;

    void OnTriggerEnter(Collider other) {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Player.GetComponent<PlayerMove.SwipePlayerActions>().enabled = false;
    }
}
