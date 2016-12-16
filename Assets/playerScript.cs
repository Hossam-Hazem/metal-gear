using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerScript : MonoBehaviour {

    List<GameObject> currentChosenItemFromInventory;

    List<List<GameObject>> itemsInventory;
    List<List<GameObject>> weaponsInventory;

    int health = 100;

	// Use this for initialization
	void Start () {
        itemsInventory = new List<List<GameObject>>();
        weaponsInventory = new List<List<GameObject>>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //attack
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //open the item menu
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //open the weapons menu
        }
        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            //activate / deactivate object

        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //pause the game
        }
	}

    void chooseItem(int i) {
        currentChosenItemFromInventory = itemsInventory[i];
    }

    void chooseWeapon(int i)
    {
        currentChosenItemFromInventory = weaponsInventory[i];
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("bullet"))
        {
            health -= 20;
        }
    }
}
