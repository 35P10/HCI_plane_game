using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;

public class game__stadistics : MonoBehaviour{

    public static int default_max_time = 400;
    public static int total_points = 10;

    public GameObject ui__txt_points;
    public GameObject ui__timer_seconds, ui__timer_minutes;
    public static int max_time;
    public static int minutes;
    public static int seconds; 
    public static int count_points = 0;
    public static bool game_over;
    private TMP_Text  TMP_Text_points;
    
    private void Start() {
        minutes = 00;
        seconds = 00;
        game_over = false;
        max_time = default_max_time;
        InvokeRepeating("timer", 0f, 1f);
    }

    private void Update() {
        ui__txt_points.GetComponent<TMP_Text>().text = (count_points).ToString();
    }

    private void timer(){
        if(max_time>0 && !game_over){
            max_time -= 1;   
            if(seconds==59){
                seconds=00;   
                minutes++;
            }
            seconds++;
            ui__timer_minutes.GetComponent<TMP_Text>().text = minutes.ToString();
            ui__timer_seconds.GetComponent<TMP_Text>().text = seconds.ToString();
        }
        else game_over = true;
    }

    public static void Restore(){
        count_points = 0;
        minutes = 00;
        seconds = 00;
        game_over = false;
        max_time = default_max_time;
    }
}
