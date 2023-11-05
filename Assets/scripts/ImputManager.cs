using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Events
    private delegate void StartTouch(Vector2 position ,float time);
    private event StartTouch OnStartTouch;
    private delegate void EndTouch(vector2 position, float time);
    private event EndTouch OnEndTouch;
    public delegate void Tapped();
    public event Tapped OnTapped;
    public delegate void MultiTapped();
    public event MultiTapped OnMultiTapped;
    public delegate void LeftSwipe();
    public event LeftSwipe OnSwipeLeft;
    public delegate void RightSwipe();
    public event RightSwipe OnSwipeRight;
    public delegate void UpSwipe();
    public event UpSwipe OnSwipeUp;
    public delegate void DownSwipe();
    public event DownSwipe OnSwipeDown;


  #endregion


   [SerializeField] private float minimumDistance = 15f;
   [SerializeField] private float maximumTime = 1f;
    [SerializeFeild, Range(0f, 1f)]private float directionThreshold = 0.9f;
    private Vector2  startPosition , endPosition;
    private float startTime, endTime;

    private PlayerControls playerControls;

    private voud Awake() =>  playerControls= new PlayerControls();

    private void OnEnable(){
        playerControls.Enable();
        OnStartTouch += SwipeStart;
        OnEndTouch += SwipeEnd;
    }

     private void OnDisable(){
        playerControls.Disable();
        OnStartTouch -= SwipeStart;
        OnEndTouch -= SwipeEnd;
    }



    
}
