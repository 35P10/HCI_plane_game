using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map__generator : MonoBehaviour{

    [Header("Map sections")]
    public GameObject[] section;

    [Header("Section parameters")]    
    public float width = 60;
    public float depth  = 60;

    [Header("Section parameters")]
    public float inset_trigger = 60;
    public float xPos_generation = 0;

    private int selectSection;
    private float zPos;

    private void Start() {
        zPos = player_timon_movement.current_position.z + depth;
    }

    // Update is called once per frame
    void Update(){
        if(player_timon_movement.current_position.z > zPos-inset_trigger){
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection(){
        selectSection=Random.Range(0,1);
        Instantiate(section[selectSection], new Vector3(xPos_generation,0,zPos),Quaternion.identity);
        zPos += depth;
        yield return new WaitForSeconds(10);
    }
}
