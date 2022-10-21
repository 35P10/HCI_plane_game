using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI__menu_controller : MonoBehaviour
{
    public GameObject ui_main_menu, ui_settings , ui_podium , ui_exit;
    /*
        1 => main menu
        2 => config_1
        3 => config_2
        4 => exit game
        5 => podium
    */
    int focus_ui;
    // Start is called before the first frame update
    void Start(){
        ui_exit.SetActive(false);
        ui_settings.SetActive(false);
        ui_podium.SetActive(false);
        ui_main_menu.SetActive(true);
        focus_ui = 1;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            switch (focus_ui){
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    action_exit_close();
                    break;
                case 5:
                    action_podium_close();
                    break;
                default:
                    break;
            }
        }
    }

    public void action_startGame(){
        SceneManager.LoadScene("game");
    }

    public void action_settings_open(){
        ui_settings.SetActive(true);
        ui_main_menu.SetActive(false);
        focus_ui = 2;
    }

    public void action_settings_close(){
        ui_settings.SetActive(false);
        ui_main_menu.SetActive(true);
        focus_ui = 1;
    }

    public void action_podium_open(){
        ui_podium.SetActive(true);
        ui_main_menu.SetActive(false);
        focus_ui = 5;
    }

    public void action_podium_close(){
        ui_podium.SetActive(false);
        ui_main_menu.SetActive(true);
        focus_ui = 1;
    }

    public void action_exit_close(){
        ui_exit.SetActive(false);
        ui_main_menu.SetActive(true);
        focus_ui = 1;
    }

    public void action_exit_open(){
        ui_exit.SetActive(true);
        ui_main_menu.SetActive(false);
        focus_ui = 4;
    }

    public void action_exit_yes(){
        Application.Quit();
    }
}
