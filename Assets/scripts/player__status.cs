using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player__status : MonoBehaviour
{
    public static Vector3 last_checkpoint = Vector3.zero;
    public static float fuel  = 10000;

    private void Update() {
        if(player__status.fuel > 0){
            fuel -= player__movement.currentSpeed;
            Debug.Log("Fuel" + fuel);
            Debug.Log("currentSpeed" + player__movement.currentSpeed);
        }
    }
}
