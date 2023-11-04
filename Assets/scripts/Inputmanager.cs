using UnityEngine;
using UnityEngine.InputSystem;


public class Inputmanager : MonoBehaviour
{

    #region Events 
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position, float time);
    public event StartTouch OnEndTouch;

    #endregion
    private PlayerControl playerControl;
    private Camera mainCamera;
    private void Awake(){
        playerControl =new PlayerControl();
        mainCamera=Camera.main;
    }

    private void OnEnable(){
        playerControl.Enable();
    }
    
    private void ONDisable(){
        playerControl.Disable();
    }


    void Start()
    {
        playerControl.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControl.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);

    }

    private void StartTouchPrimary(InputAction.CallbackContext context){
        if(OnStartTouch != null ) OnStartTouch(Utils.ScreenToWorld(mainCamera, playerControl.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);


    }
     private void EndTouchPrimary(InputAction.CallbackContext context){
        if(OnEndTouch != null ) OnEndTouch(Utils.ScreenToWorld(mainCamera, playerControl.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);


    }
    

    public Vector2 PrimaryPosition(){
        return Utils.ScreenToWorld(mainCamera, playerControl.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
