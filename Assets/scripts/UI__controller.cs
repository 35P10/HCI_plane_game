using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI__controller : MonoBehaviour
{
    public GameObject ui_lose, ui_win, ui_pause, ui_exitToMenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start(){
        ui_lose.SetActive(false);
        ui_win.SetActive(false);
        ui_pause.SetActive(false);
        ui_exitToMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if(game__stadistics.max_time==-1){
            f_time_over();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    void f_time_over(){
        ui_lose.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseGame(){
        ui_pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        ui_pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void open_exitGame(){
        ui_pause.SetActive(false);
        ui_exitToMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void exitGame_yes(){
        SceneManager.LoadScene("menu");
    }

    public void exitGame_no(){
        ui_exitToMenu.SetActive(false);
        ui_pause.SetActive(true);
    }

    void you_win(){
        ui_win.SetActive(true);
        Time.timeScale = 0f;
    }
}
