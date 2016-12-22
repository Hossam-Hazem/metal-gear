using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
    public GameObject resumeButton;
    public GameObject insButton;
    public GameObject muteButton;
    public GameObject exitButton;
    public GameObject panel;
    public GameObject muteText;
    public GameObject instructions;
    public GameObject menuButtons;
    bool mute = false;
    bool clicked = false;
	// Use this for initialization
	void Start () {
        instructions.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void resume()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void muteSound()
    {
        if (mute)
        {
            AudioListener.pause = true;
            muteText.GetComponentInChildren<Text>().text = "Unmute";
        }
        else
        { 
            AudioListener.pause = false;
            muteText.GetComponentInChildren<Text>().text = "Mute";
        }
    }


    public void toggleMute()
    {
        mute = !mute;
        muteSound();
    }

    public void instructionButton()
    {
        if (!clicked)
        {
            menuButtons.SetActive(false);
            instructions.SetActive(true);
            clicked = true;
        }
        else
        {
            menuButtons.SetActive(true);
            instructions.SetActive(false);
            clicked = false;
        }
    }

    public void closeInstructions()
    {
        clicked = false;
        menuButtons.SetActive(true);
        instructions.SetActive(false);
    }

}
