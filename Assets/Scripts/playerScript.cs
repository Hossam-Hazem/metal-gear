using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class playerScript : MonoBehaviour
{

    // inventory items : heal, box, key
    // inventory weapons : knock, pistol

    bool isDead = false;
    public static bool isInBox = false;

    string currentChosenItemFromInventory = "";

    int healItems = 0;
    bool box = true;
    bool key = false;

    bool knock = true;
    int pistolAmmo = 20;

    int health = 100;

    ThirdPersonUserControl thirdPersonUserControl;
    ThirdPersonCharacter m_Character;
    GameObject aimDot;

    GameObject parentMainCamera;
    GameObject mainCamera;
    GameObject MainCameraPivot;
    Animator animator;

    public GameObject boxGameObject;
    public GameObject snakeGameObject;
    public GameObject bullet;
    public GameObject aimTarget;
    GameObject aimTargetClone;
    float lastBulletWaitTime = 0f;

    // Use this for initialization
    void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        animator = GetComponent<Animator>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        aimDot = GameObject.FindWithTag("aimDot");

        parentMainCamera = GameObject.FindWithTag("mainCamera");
        mainCamera = GameObject.FindWithTag("MainCamera");
        MainCameraPivot = GameObject.FindWithTag("MainCameraPivot");


        currentChosenItemFromInventory = "pistol";
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && animator.GetBool("Aim"))
        {
            //attack
            OnAttackClicked();
        }

        Destroy(aimTargetClone);
        if (Input.GetMouseButton(1) && animator.GetBool("Pistol"))
        {
            //aiming
            animator.SetBool("Aim", true);
            transform.rotation = Quaternion.LookRotation(parentMainCamera.transform.forward);

            Ray ray = new Ray();
            RaycastHit raycastHit;
            ray.origin = bullet.transform.position;
            ray.direction = mainCamera.transform.forward;
            if (Physics.SphereCast(ray, 0.009f, out raycastHit, Mathf.Infinity) && !raycastHit.transform.CompareTag("snakeBullet"))
            {
                aimTargetClone = (GameObject)Instantiate(aimTarget, raycastHit.point, aimTarget.transform.rotation);
            }
        }
        else
        {
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
        if (collider.CompareTag("enemyBullet"))
        {
            health -= 20;
            if (health <= 0 && !isDead)
            {
                isDead = true;
                animator.SetBool("Ded", true);
                thirdPersonUserControl.enabled = false;
            }
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
            if (Time.time - lastBulletWaitTime > 0.5)
            {

                pistolAmmo--;
                animator.SetBool("Fire", true);

                GameObject bulletClone = (GameObject)Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
                bulletClone.transform.localScale *= 300;
                Rigidbody bulletCloneRigid = bulletClone.GetComponent<Rigidbody>();
                bulletCloneRigid.isKinematic = false;
                bulletCloneRigid.velocity = mainCamera.transform.forward * 200f;
                bulletClone.SetActive(true);

                Destroy(bulletClone, 2.0f);
            }
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
            if (isInBox)
            {
                isInBox = false;
                boxGameObject.SetActive(false);
                snakeGameObject.SetActive(true);
                thirdPersonUserControl.enabled = true;
            }
            else
            {
                isInBox = true;
                boxGameObject.SetActive(true);
                snakeGameObject.SetActive(false);
                thirdPersonUserControl.enabled = false;
            }
        }

        else if (currentChosenItemFromInventory.Equals("knock"))
        {
            //knock anim to draw enemy's attention
            GameObject currentLocation = new GameObject();
            currentLocation.transform.position = transform.position;
            if (guardPath.destinationSnakeCurrentLocation != null)
            {
                Destroy(guardPath.destinationSnakeCurrentLocation.gameObject);
            }
            guardPath.destinationSnakeCurrentLocation = currentLocation.transform;
        }
        else if (currentChosenItemFromInventory.Equals("pistol"))
        {
            //toggle pistol anim
            if (animator.GetBool("Pistol"))
            {
                animator.SetBool("Pistol", false);
            }
            else
            {
                animator.SetBool("Pistol", true);
            }
        }
    }
}
