using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using System;

public class UI__controller : MonoBehaviour
{
    public GameObject ui_text_score, ui_pause, ui_exitToMenu, ui_configuracion, ui_newScoreRecord, ui_podio, ui_reiniciar, ui_gameover ,ui_text_gameover_title, ui_text_gameover_score;
    /*
        0 => game
        1 => pause
        2 => config_1
        3 => config_2
        4 => restart
        5 => back to main menu
        6 => podium
    */
    int focus_ui = 0;
    private TMP_Text  TMP_Text_score;

    // Start is called before the first frame update
    void Start(){
        ui_pause.SetActive(false);
        ui_exitToMenu.SetActive(false);
        ui_newScoreRecord.SetActive(false);
        ui_configuracion.SetActive(false);
        ui_podio.SetActive(false);
        ui_reiniciar.SetActive(false);
        ui_gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if(game__stadistics.time_over || player__status.fuel < 0){
            game_over("PERDISTE");
        }
        else if(game__stadistics.count_points == game__stadistics.total_points){
            game_over("GANASTE");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            switch (focus_ui){
                case 0:
                    PauseGame();
                    break;
                case 1:
                    ResumeGame();
                    break;
                case 2:
                    config_exit();
                    break;
                case 4:
                    restartGame_no();
                    break;
                case 5:
                    exitGame_no();
                    break;
                case 6:
                    podium_exit();
                    break;
                default:
                    break;
            }
        }
    }

    void game_over(string mensaje){
        ui_text_gameover_title.GetComponent<TMP_Text>().text = mensaje ;
        ui_text_gameover_score.GetComponent<TMP_Text>().text = game__stadistics.minutes.ToString() + " : " + game__stadistics.seconds.ToString() ;
        Time.timeScale = 0f;
        ui_gameover.SetActive(true);
        ui_pause.SetActive(false);
        ui_exitToMenu.SetActive(false);
        ui_newScoreRecord.SetActive(false);
        ui_configuracion.SetActive(false);
        ui_podio.SetActive(false);
        ui_reiniciar.SetActive(false);
    }

    public void PauseGame(){
        ui_text_score.GetComponent<TMP_Text>().text = game__stadistics.minutes.ToString() + " : " + game__stadistics.seconds.ToString() ;
        Time.timeScale = 0f;
        ui_pause.SetActive(true);
        focus_ui=1;
    }

    public void RestartGame(){
        //aniadir default settings
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame(){
        ui_pause.SetActive(false);
        focus_ui=0;
        Time.timeScale = 1f;
    }

    public void open_restartGame(){
        ui_pause.SetActive(false);
        ui_reiniciar.SetActive(true);
        Time.timeScale = 0f;
        focus_ui=4;
    }

    public void restartGame_no(){
        ui_pause.SetActive(true);
        ui_reiniciar.SetActive(false);
        focus_ui=1;
    }

    public void open_exitGame(){
        ui_pause.SetActive(false);
        ui_exitToMenu.SetActive(true);
        Time.timeScale = 0f;
        focus_ui=5;
    }

    public void exitGame_yes(){
        SceneManager.LoadScene("menu");
    }

    public void exitGame_no(){
        ui_exitToMenu.SetActive(false);
        ui_pause.SetActive(true);
        focus_ui=1;
    }

    public void open_podium(){
        ui_pause.SetActive(false);
        ui_podio.SetActive(true);
        focus_ui=6;
    }

    public void open_config(){
        ui_pause.SetActive(false);
        ui_configuracion.SetActive(true);
        focus_ui=2;
    }

    public void config_exit(){
        ui_configuracion.SetActive(false);
        ui_pause.SetActive(true);
        focus_ui=1;
    }

    public void podium_exit(){
        ui_podio.SetActive(false);
        ui_pause.SetActive(true);
        focus_ui=1;
    }
}
