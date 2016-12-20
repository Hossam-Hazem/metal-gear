using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject weaponsPanel;
    public GameObject pausePanel;

    public void Start()
    {
        weaponsPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void loadScene(string selectScene)
    {
        SceneManager.LoadScene(selectScene);
    }


    public void exitButton()
    {
        Application.Quit();
    }

    public void weaponsMenu()
    {
        // TODO
        weaponsPanel.SetActive(true);
    }

    public void closeWeaponsPanel()
    {
        weaponsPanel.SetActive(false);
    }

    public void pauseMenu()
    {
        // TODO
        pausePanel.SetActive(true);
    }

    public void closePausePanel(string btn)
    {
        pausePanel.SetActive(false);
    }
}
