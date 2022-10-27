using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player__collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "tag_point"){
            other.gameObject.SetActive(false);
            game__stadistics.count_points += 1;
            player__movement.last_checkpoint = transform.position;
        }

        if (other.gameObject.tag == "tag_obstacle"){
            Debug.Log("Collision!!!!");
            transform.position = player__movement.last_checkpoint;
        }
    }
}
