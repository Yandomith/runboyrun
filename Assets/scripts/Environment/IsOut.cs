using UnityEngine;

public class IsOut : MonoBehaviour
{
    public GameObject Player;
    public GameObject Environment;
    void Update()
    {
        if((Player.GetComponent<PlayerMove.SwipePlayerActions>().enabled == false)&&(Player.GetComponent<JumpAndDuckScript>().enabled == false))
        {
            Environment.GetComponent<EnvironmentMove>().enabled = false;
            Environment.GetComponent<Destroy>().enabled = false;
            
        }
    }
}
