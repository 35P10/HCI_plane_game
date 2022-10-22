using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player__status : MonoBehaviour{
    public GameObject obj__row_fuel;
    public static Vector3 last_checkpoint = Vector3.zero;
    public static float default_fuel  = 50000;
    public static float fuel;

    private void Start() {
        fuel = default_fuel;
    }

    private void Update() {
        if(player__status.fuel > 0){
            fuel -= player__movement.currentSpeed;
            obj__row_fuel.transform.localRotation = Quaternion.Euler(0, 140 * fuel / default_fuel, 0);
        }
    }
}
