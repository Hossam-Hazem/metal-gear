using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerScript : MonoBehaviour
{

    // inventory items : heal, box, key
    // inventory weapons : knock, pistol

    string currentChosenItemFromInventory = "";

    int healItems = 0;
    bool box = false;
    bool key = false;

    bool knock = true;
    int pistolAmmo = 0;

    int health = 100;


    Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Fire", false);

        if (Input.GetMouseButtonDown(0) && animator.GetBool("Aim"))
        {
            //attack
            OnAttackClicked();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            //aiming
            animator.SetBool("Aim", true);
        }
        else {
            animator.SetBool("Aim", false);
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
            OnAltClick();
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //pause the game
        }
    }

    void chooseItem(string item)
    {
        currentChosenItemFromInventory = item;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("bullet"))
        {
            health -= 20;
        }

        if (collider.CompareTag("door"))
        {
            //go to another scene
        }

        if (collider.CompareTag("health"))
        {
            healItems++;
        }

        if (collider.CompareTag("box"))
        {
            box = true;
        }

        if (collider.CompareTag("doorCard"))
        {
            key = true;
        }

        if (collider.CompareTag("ammo"))
        {
            pistolAmmo += 30;
        }
    }

    void OnAttackClicked()
    {
        if (currentChosenItemFromInventory.Equals("health"))
        {
            //do nothing
        }
        else if (currentChosenItemFromInventory.Equals("box"))
        {
            //do nothing
        }

        else if (currentChosenItemFromInventory.Equals("knock"))
        {
            //do nothing
        }
        else if (currentChosenItemFromInventory.Equals("pistol"))
        {
            pistolAmmo--;
            animator.SetBool("Fire", true);
        }
    }

    void OnAltClick()
    {

        if (currentChosenItemFromInventory.Equals("health"))
        {
            health = 100;
            healItems--;
        }
        else if (currentChosenItemFromInventory.Equals("box") && box)
        {
            //show box hide character / hide box show character
            if (animator.GetBool("inBox"))
            {
                animator.SetBool("inBox", false);
            }
            else {
                animator.SetBool("inBox", true);
            }
        }

        else if (currentChosenItemFromInventory.Equals("knock"))
        {
            //knock anim to draw enemy's attention

        }
        else if (currentChosenItemFromInventory.Equals("pistol"))
        {
            //toggle pistol anim
        }
    }
}
