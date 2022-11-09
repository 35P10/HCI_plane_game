using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_timon_movement : MonoBehaviour
{
    [Header("Controller")]
    public OVRInput.Button grabButton;    
    public OVRInput.Button LeftPedal;
    public OVRInput.Button RightPedal;

    [Header("controlWheel")]
    public GameObject controlWheel;

    [Header("player")]
    public GameObject player;

    [Header("hand")]
    public GameObject hand;
 
    [Header("Activation Settings")]
    public float activationDistance;
 

    [Header("Rotating speeds")]
    [Range(5f, 500f)]
    [SerializeField] private float yawSpeed = 50f;

    [Range(5f, 500f)]
    [SerializeField] private float pitchSpeed = 100f;

    [Range(5f, 500f)]
    [SerializeField] private float rollSpeed = 200f;

    [Header("Rotating speeds multiplers when turbo is used")]
    [Range(0.1f, 5f)]
    [SerializeField] private float yawTurboMultiplier = 0.3f;

    [Range(0.1f, 5f)]
    [SerializeField] private float pitchTurboMultiplier = 0.5f;

    [Range(0.1f, 5f)]
    [SerializeField] private float rollTurboMultiplier = 1f;

    [Header("Moving speed")]
    [Range(5f, 100f)]
    [SerializeField] private float defaultSpeed = 10f;

    [Range(10f, 200f)]
    [SerializeField] private float turboSpeed = 20f;

    [Range(0.1f, 50f)]
    [SerializeField] private float accelerating = 10f;

    [Range(0.1f, 50f)]
    [SerializeField] private float deaccelerating = 5f;

    private float maxSpeed = 0.6f;
    private float currentYawSpeed;
    private float currentPitchSpeed;
    private float currentRollSpeed;
    static public float currentSpeed;
    private Quaternion currentRot;
    private Vector3 default_controlWheel_position;
    private Quaternion pressPoint;
    private bool offsetSet;
    public float RotationSpeed = 5;

    private Quaternion initialObjectRotation;
    private Quaternion initialControllerRotation;
    private bool set = false;

    public static Vector3 last_checkpoint;
    public static Vector3 current_position;

 
    private void Start(){
        last_checkpoint = player.transform.position;
        current_position  = player.transform.position;

        offsetSet = false;
        default_controlWheel_position = controlWheel.transform.localEulerAngles;
    }
 
    // Update is called once per frame
    void Update(){

        current_position  = player.transform.position;

        //mover hacia adelante
        player.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        //rotar
        player.transform.Rotate(Vector3.forward * -Input.GetAxis("Horizontal") * currentRollSpeed * Time.deltaTime);
        player.transform.Rotate(Vector3.right * Input.GetAxis("Vertical") * currentPitchSpeed * Time.deltaTime);


        //Rotate yaw
        if(Input.GetKey(KeyCode.E) || OVRInput.Get(RightPedal)){
            player.transform.Rotate(Vector3.up * currentYawSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.Q) || OVRInput.Get(LeftPedal)){
            player.transform.Rotate(-Vector3.up * currentYawSpeed * Time.deltaTime);
        }

        if(currentSpeed < maxSpeed){
            currentSpeed += accelerating * Time.deltaTime;
        }
        else {
            currentSpeed -= deaccelerating * Time.deltaTime;
        }

        //Turbo
        if (Input.GetKey(KeyCode.LeftShift)){
            //Set speed to turbo speed and rotation to turbo values
            maxSpeed = turboSpeed;
            currentYawSpeed = yawSpeed * yawTurboMultiplier;
            currentPitchSpeed = pitchSpeed * pitchTurboMultiplier;
            currentRollSpeed = rollSpeed * rollTurboMultiplier;
        }
        else {
            //Speed and rotation normal
            maxSpeed = defaultSpeed;
            currentYawSpeed = yawSpeed;
            currentPitchSpeed = pitchSpeed;
            currentRollSpeed = rollSpeed;
        }


        if (OVRInput.Get(grabButton) && IsCloseEnough()) {
            if(set == false){
                 initialObjectRotation= controlWheel.transform.localRotation;
                 initialControllerRotation = hand.transform.rotation;
                 set = true;
            }

            //controlWheel rotation z axis + player movement
            Quaternion controllerAngularDifference = initialControllerRotation * Quaternion.Inverse(hand.transform.rotation);
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(0,  0, controllerAngularDifference.y, 1);
            controlWheel.transform.localRotation = newQuaternion * initialObjectRotation;

            newQuaternion.Set(0, 0, controllerAngularDifference.y, 1);
            Vector3 v = newQuaternion.ToEulerAngles();
            player.transform.Rotate(v * currentPitchSpeed * Time.deltaTime);


            //player rotation
            Quaternion newQuaternion2 = new Quaternion();
            newQuaternion2.Set(controllerAngularDifference.z, 0, 0, 1);
            v = newQuaternion2.ToEulerAngles();
            player.transform.Rotate(v * currentPitchSpeed * Time.deltaTime);
        }         
        else{
            set = false;
            controlWheel.transform.localEulerAngles = default_controlWheel_position;
        }
    }
 
    void SetOffsets(){
        if(offsetSet)
            return;
 
        currentRot = controlWheel.transform.rotation;
        pressPoint = hand.transform.rotation;
 
        offsetSet = true;
    }
  
    bool IsCloseEnough(){
        //if (Mathf.Abs(Vector3.Distance(transform.position, controlWheel.transform.position)) < activationDistance)
            return true;
 
        //return false;
    }
}
