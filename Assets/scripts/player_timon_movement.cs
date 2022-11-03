using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_timon_movement : MonoBehaviour
{
    [Header("Controller")]
    public OVRInput.Button grabButton;
    public OVRInput.Button resetRotationButton;

 
    [Header("timon")]
    public GameObject timon;

    [Header("hand")]
    public GameObject hand;
 
    [Header("Activation Settings")]
    public float activationDistance;
 
    private Quaternion currentRot;
    Vector3 default_timon_position;
    Vector3 pressPoint;
    private bool offsetSet;
 
    private void Start(){
        offsetSet = false;
        default_timon_position = timon.transform.localEulerAngles;
    }
 
    // Update is called once per frame
    void Update(){
        if (OVRInput.Get(grabButton) && IsCloseEnough())
            Rotate();
        else
            offsetSet = false;
 
        if (OVRInput.GetDown(resetRotationButton))
            timon.transform.localEulerAngles = default_timon_position;
    }
 
    void SetOffsets(){
        if (offsetSet)
            return;
 

        currentRot = timon.transform.rotation;
        pressPoint = hand.transform.position;
 
        offsetSet = true;
    }
 
    void Rotate(){
        SetOffsets();
        float closestPoint = (hand.transform.position - pressPoint).x;
        timon.transform.localRotation = currentRot * Quaternion.Euler(0, 0, closestPoint);
    }
 
    bool IsCloseEnough(){
        //if (Mathf.Abs(Vector3.Distance(transform.position, timon.transform.position)) < activationDistance)
            return true;
 
        //return false;
    }
}
