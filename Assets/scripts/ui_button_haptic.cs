using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_button_haptic : MonoBehaviour
{
    [Header("Button hover")]
    public float hover_amplitude = 0.5f;

    // Start is called before the first frame update
    public void ui_button_hover(){
        OVRInput.SetControllerVibration(1f, hover_amplitude, OVRInput.Controller.RTouch);
        StartCoroutine(ui_button_hover_disable(0.2f));
    }

    private IEnumerator ui_button_hover_disable(float waitTime){
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }

}
