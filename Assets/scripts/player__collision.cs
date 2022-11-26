using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player__collision : MonoBehaviour
{
    public AudioClip point_collision_audio;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "tag_point"){
            other.gameObject.SetActive(false);
            game__stadistics.count_points += 1;
            player_timon_movement.last_checkpoint = transform.position;
            player_timon_movement.last_checkpoint_rot = transform.rotation;
            AudioSource.PlayClipAtPoint(point_collision_audio, transform.position);
        }

        if (other.gameObject.tag == "tag_obstacle"){
            player_timon_movement.isTouchIt = false;
            player_timon_movement.isTouchIt2 = false;
            Debug.Log("Collision!!!!");
            transform.position = player_timon_movement.last_checkpoint;
            transform.rotation = player_timon_movement.last_checkpoint_rot;
        }
    }
}
