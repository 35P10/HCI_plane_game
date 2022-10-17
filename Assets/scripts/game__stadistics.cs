using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;

public class game__stadistics : MonoBehaviour{
    public GameObject ui__txt_points;
    public GameObject ui__timer_seconds, ui__timer_minutes;
    public static int max_time = 10;
    private static int minutes;
    private static int seconds; 
    public static int count_points = 0;
    public static bool time_over;
    private TMP_Text  TMP_Text_points;
    
    private void Start() {
        minutes = max_time/60;
        seconds = max_time%60;
         time_over = false;
         InvokeRepeating("timer", 0f, 1f);
    }

    private void Update() {
        TMP_Text_points = ui__txt_points.GetComponent<TMP_Text>();
        TMP_Text_points.text = (count_points).ToString();
    }

    private void timer(){
        if(max_time>-1){
        max_time -= 1;   
        ui__timer_minutes.GetComponent<TMP_Text>().text =minutes.ToString();
        ui__timer_seconds.GetComponent<TMP_Text>().text =seconds.ToString();
            if(seconds==0){
                seconds=59;   
                minutes--;
            }
            seconds-=1;
        }
    }
}
