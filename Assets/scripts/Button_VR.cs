using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Button_VR : MonoBehaviour{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    public static bool button_pause_isPressed;
    bool ispressed;

    void Start() {
        button_pause_isPressed = false;   
        ispressed = false; 
    }

    private void OnTriggerEnter(Collider other){
        if (ispressed == false){
            ispressed = true;
            presser = other.gameObject;
            button_pause_isPressed = !button_pause_isPressed;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject == presser){         
            ispressed = false;
        }
    }
}
