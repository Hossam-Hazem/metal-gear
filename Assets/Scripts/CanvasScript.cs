using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    // Use this for initialization
    public GameObject pausePanel;
	void Start () {
        pausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.active)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.active)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
	}
}
