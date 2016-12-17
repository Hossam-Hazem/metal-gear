using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void loadScene(string selectScene)
    {
        Debug.Log("Load Scenes" + selectScene);
        SceneManager.LoadScene(selectScene);
    }

    
    public void exitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
