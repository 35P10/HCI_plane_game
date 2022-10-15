using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player__movement : MonoBehaviour
{
    public static float speed=2f;
    public static Vector3 pos_start;
    public static Vector3 pos_curr;

    // Start is called before the first frame update
    void Start(){
        pos_start=this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.Self);
        //pos_curr = this.gameObject.transform.position;
        if(Input.GetKey(KeyCode.A) && this.gameObject.transform.position.x > map__settings.left_limit)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if(Input.GetKey(KeyCode.D) && this.gameObject.transform.position.x < map__settings.right_limit)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        if(Input.GetKey(KeyCode.W) && this.gameObject.transform.position.y < map__settings.up_limit)
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(Input.GetKey(KeyCode.S) && this.gameObject.transform.position.y > map__settings.down_limit)
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        if(Input.GetKey(KeyCode.Q) && this.gameObject.transform.position.y > map__settings.down_limit)
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.E) && this.gameObject.transform.position.y > map__settings.down_limit)
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
