using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public GameObject weaponsPanel;
    public GameObject pausePanel;
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject exitGameButton;
    public GameObject LevelOne;
    public GameObject LevelTwo;

    private bool startMoving = false;
    private bool optionsMoving = false;
    private bool exitMoving = false;
    float speed = 1.0f;
    float FadeSpeed = 0f;
    float OptionsFadeSpeed = 0f;
    float OptionsSpeed = 1.0f;
    float exitFadeSpeed = 0f;
    float exitSpeed = 1.0f;

    private bool l1Moving = false;
    private bool l2Moving = false;
    float l1Speed = 11.2f;
    float l1FadeSpeed = 0f;
    float l2Speed = 11.2f;
    float l2FadeSpeed = 0f;

    public void Start()
    {
        //weaponsPanel.SetActive(false);
        //pausePanel.SetActive(false);

        Debug.Log(LevelOne.transform.position[0]);
        Debug.Log("Button Started At: " + startButton.transform.position[0]);
        LevelOne.SetActive(false);
        LevelTwo.SetActive(false);
    }
    void Update()
    {
        if (startMoving)
        {
            speed += 0.2f;
            FadeSpeed += 0.02f;
            startButton.transform.Translate(1 * speed, 0f, 0);
            ColorBlock cb = startButton.GetComponent<Button>().colors;
            cb.highlightedColor = new Color (1,1,1,1 - FadeSpeed);
            startButton.GetComponent<Button>().colors = cb;
            startButton.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1 - FadeSpeed);
            if (1 - FadeSpeed < 0.75)
            {
                optionsMoving = true;
            }
            if (1 - FadeSpeed < 0)
            {
                startMoving = false;
                Debug.Log("Button ended at" + startButton.transform.position[0]);
            }
        }
        if (optionsMoving)
        {
            OptionsSpeed += 0.2f;
            OptionsFadeSpeed += 0.02f;
            optionsButton.transform.Translate(1 * OptionsSpeed, 0f, 0);
            ColorBlock cb = optionsButton.GetComponent<Button>().colors;
            cb.highlightedColor = new Color(1, 1, 1, 1 - OptionsFadeSpeed);
            optionsButton.GetComponent<Button>().colors = cb;
            optionsButton.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1 - OptionsFadeSpeed);
            if (1 - OptionsFadeSpeed < 0.75)
            {
                exitMoving = true;
            }
            if (1 - OptionsFadeSpeed < 0)
            {
                optionsMoving = false;
            }
        }
     
        if (exitMoving)
        {
            exitSpeed += 0.2f;
            exitFadeSpeed += 0.02f;
            exitGameButton.transform.Translate(1 * exitSpeed, 0f, 0);
            ColorBlock cb = exitGameButton.GetComponent<Button>().colors;
            cb.highlightedColor = new Color(1, 1, 1, 1 - exitFadeSpeed);
            exitGameButton.GetComponent<Button>().colors = cb;
            exitGameButton.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1 - exitFadeSpeed);
            if (1 - exitFadeSpeed < 0)
            {
                exitMoving = false;
                l1Moving = true;
            }
        }

        if (l1Moving)
        {
            l1Speed -= 0.2f;
            Debug.Log(l1Speed);
            l1FadeSpeed += 0.02f;
            LevelOne.transform.Translate(1 * l1Speed, 0f, 0);
            ColorBlock cb = LevelOne.GetComponent<Button>().colors;
            cb.highlightedColor = new Color(1, 1, 1, l1FadeSpeed);
            LevelOne.GetComponent<Button>().colors = cb;
            LevelOne.GetComponentInChildren<Text>().color = new Color(1, 1, 1, l1FadeSpeed);
            LevelOne.SetActive(true);
            Debug.Log(LevelOne.transform.position[0]);
            if (l1FadeSpeed >= 0.25)
                l2Moving = true;
            if (LevelOne.transform.position[0] > 225)
            {
                l1Moving = false;
            }
        }


        if (l2Moving)
        {
            l2Speed -= 0.2f;
            l2FadeSpeed += 0.02f;
            LevelTwo.transform.Translate(1 * l2Speed, 0f, 0);
            ColorBlock cb = LevelOne.GetComponent<Button>().colors;
            cb.highlightedColor = new Color(1, 1, 1, l2FadeSpeed);
            LevelTwo.GetComponent<Button>().colors = cb;
            LevelTwo.GetComponentInChildren<Text>().color = new Color(1, 1, 1, l2FadeSpeed);
            LevelTwo.SetActive(true);

            if (LevelTwo.transform.position[0] > 224)
            {
                l2Moving = false;
            }
        }

    }

   
    public void loadScene(string selectScene)
    {
        startMoving = true;
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
