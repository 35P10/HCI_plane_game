using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI__menu_controller : MonoBehaviour
{
    public GameObject ui_main_menu, ui_settings , ui_podium , ui_exit;
    // Start is called before the first frame update
    void Start()
    {
        ui_exit.SetActive(false);
        ui_settings.SetActive(false);
        ui_podium.SetActive(false);
    }

    public void action_startGame(){
        SceneManager.LoadScene("game");
    }

    public void action_settings_open(){
        ui_settings.SetActive(true);
        ui_main_menu.SetActive(false);
    }

    public void action_settings_close(){
        ui_settings.SetActive(false);
        ui_main_menu.SetActive(true);
    }

    public void action_podium_open(){
        ui_podium.SetActive(true);
        ui_main_menu.SetActive(false);
    }

    public void action_podium_close(){
        ui_podium.SetActive(false);
        ui_main_menu.SetActive(true);
    }

    public void action_exit_close(){
        ui_exit.SetActive(false);
        ui_main_menu.SetActive(true);
    }

    public void action_exit_open(){
        ui_exit.SetActive(true);
        ui_main_menu.SetActive(false);
    }

    public void action_exit_yes(){
        Application.Quit();
    }
}
