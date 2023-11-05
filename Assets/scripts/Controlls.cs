using UnityEngine;

public class Controlls : MonoBehaviour
{
   private InputManager inputManager;


   private void Awake()
   {
    inputManager = GetComponent<InputManager>();
   }
   private void OnEnable(){
    inputManager.OnSwipeLeft += OnSwipeLeft;
    inputManager.OnSwipeRight += OnSwipeRight;
    inputManager.OnSwipeUp += OnSwipeUp;
    inputManager.OnSwipeDown += OnSwipeDown;
   }

   private void OnDisable(){
    inputManager.OnSwipeLeft -= OnSwipeLeft;
    inputManager.OnSwipeRight -= OnSwipeRight;
    inputManager.OnSwipeUp -= OnSwipeUp;
    inputManager.OnSwipeDown -= OnSwipeDown;
   }

   private void OnSwipeLeft()
   {
        Debug.Log("left");
   }


    private void OnSwipeRight()
   {
        Debug.Log("Right");
   }


    private void OnSwipeUp()
   {
        Debug.Log("UP");
   }

    private void OnSwipeDown()
   {
        Debug.Log("Down");
   }
}
