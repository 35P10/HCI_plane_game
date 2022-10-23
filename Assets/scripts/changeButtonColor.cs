using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class changeButtonColor : MonoBehaviour
{
    public Color wantedColor;
    public Color originalColor;

    public Button button_screen;
    public Button button_sound;

    public Image img_screen;
    public Image img_sound;

    public GameObject panel_screen_settings;
    public GameObject panel_sound_settings;

    // Start is called before the first frame update
    void Start(){
        ButtonSelectedSound();
    }
    private void Awake(){
        // adding a delegate with no parameters
    }
    // Update is called once per frame
    void Update(){
        
    }


    public void ButtonSelectedScreen(){
        panel_screen_settings.SetActive(true);
        panel_sound_settings.SetActive(false);

        button_sound.GetComponent<Image>().color = originalColor;
        button_screen.GetComponent<Image>().color = wantedColor;

        img_screen.color = originalColor;
        img_sound.color = wantedColor;
    }

    public void ButtonSelectedSound(){
        panel_screen_settings.SetActive(false);
        panel_sound_settings.SetActive(true);

        button_screen.GetComponent<Image>().color = originalColor;
        button_sound.GetComponent<Image>().color = wantedColor;

        img_screen.color = wantedColor;
        img_sound.color = originalColor;
    }

}
