using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel_collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "tag_l_hand"){
            Debug.Log("Wheel cogido");
            player_timon_movement.isTouchIt = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "tag_l_hand"){
            player_timon_movement.isTouchIt = false;
            Debug.Log("Wheel dejado");
        }
    }
}
