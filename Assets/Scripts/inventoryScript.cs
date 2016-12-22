using UnityEngine;
using System.Collections;

public class inventoryScript : MonoBehaviour {
    public GameObject inventoryCanvas;
    bool opened = false;
    // Use this for initialization
    void Start () {
        inventoryCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && !opened)
        {
            opened = true;
            inventoryCanvas.SetActive(true);
        }
       else  if (Input.GetKeyDown(KeyCode.Escape) && opened)
        {
            opened = false;
            inventoryCanvas.SetActive(false);
        }
    }
}
