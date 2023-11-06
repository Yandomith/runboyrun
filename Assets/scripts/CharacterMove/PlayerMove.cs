using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float LeftRightSpeed= 10;
    

    void Update()
    {  

        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x >LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime*LeftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x <LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime*LeftRightSpeed *-1);
            }
        }
        

    }
}
