using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throttle_collision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "tag_r_hand"){
            Debug.Log("Wheel cogido");
            player_timon_movement.isTouchIt2 = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "tag_r_hand"){
            player_timon_movement.isTouchIt2 = false;
            Debug.Log("Wheel dejado");
        }
    }


}
