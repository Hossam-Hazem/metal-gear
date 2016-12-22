using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{

    // inventory items : heal, box, key
    // inventory weapons : knock, pistol
    public static bool hasKilledBoss = false;
    
    bool isDead = false;
    public static bool isInBox = false;

    string currentChosenItemFromInventory = "";

    int healItems = 0;
    bool box = false;
    bool key = false;

    bool knock = true;
    int pistolAmmo = 20;

    int health = 100;

    AudioSource gunShot;
    AudioSource ssHurt;
    AudioSource ssDeath;
    AudioSource footSteps;
    AudioSource doorOpening;

    ThirdPersonUserControl thirdPersonUserControl;
    ThirdPersonCharacter m_Character;
    GameObject aimDot;

    GameObject parentMainCamera;
    GameObject mainCamera;
    GameObject MainCameraPivot;
    Animator animator;

    public Button healB;
    public Button boxB;
    public Button keyB;
    public Button knockB;
    public Button pistolB;

    public GameObject inventoryCanvas;
    public GameObject boxGameObject;
    public GameObject snakeGameObject;
    public GameObject bullet;
    public GameObject aimTarget;
    GameObject aimTargetClone;

    float lastBulletWaitTime = 0f;

    float lastStepTime = 0f;

    // Use this for initialization
    void Start()
    {
        hasKilledBoss = false;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        gunShot = audioSources[0];
        ssHurt = audioSources[1];
        ssDeath = audioSources[2];
        footSteps = audioSources[3];
        doorOpening = audioSources[4];

        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        animator = GetComponent<Animator>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        aimDot = GameObject.FindWithTag("aimDot");

        parentMainCamera = GameObject.FindWithTag("mainCamera");
        mainCamera = GameObject.FindWithTag("MainCamera");
        MainCameraPivot = GameObject.FindWithTag("MainCameraPivot");

        // inventory items : heal, box, key
        // inventory weapons : knock, pistol
        healB.onClick.AddListener(() =>
        {
            chooseItem("health");
            inventoryCanvas.SetActive(false);
        });
        boxB.onClick.AddListener(() =>
        {
            chooseItem("box");
            inventoryCanvas.SetActive(false);
        });
        keyB.onClick.AddListener(() =>
        {
            chooseItem("key");
            inventoryCanvas.SetActive(false);
        });
        knockB.onClick.AddListener(() =>
        {
            chooseItem("knock");
            inventoryCanvas.SetActive(false);
        });
        pistolB.onClick.AddListener(() =>
        {
            chooseItem("pistol");
            inventoryCanvas.SetActive(false);
        });

        currentChosenItemFromInventory = "knock";
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
            if (!inventoryCanvas.activeSelf)
            {
                //open the item menu
                inventoryCanvas.SetActive(true);
            }
            else
            {
                inventoryCanvas.SetActive(false);
            }
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

        

        if (Time.time - lastStepTime > 0.35)
        {
            lastStepTime = Time.time;
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !animator.GetBool("Crouch"))
            {
                footSteps.Play();
            }
            else
            {
                footSteps.Stop();
            }
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
            ssHurt.Play();
            if (health <= 0 && !isDead)
            {
                isDead = true;
                animator.SetBool("Ded", true);
                thirdPersonUserControl.enabled = false;
                ssDeath.Play();
                SceneManager.LoadScene("Credits");
            }
        }

        if (collider.CompareTag("door") && hasKilledBoss)
        {
            //go to another scene
            doorOpening.Play();
            SceneManager.LoadScene("Credits");
        }

        if (collider.CompareTag("door") && key)
        {
            //go to another scene
            doorOpening.Play();
            SceneManager.LoadScene("LevelTwo");
        }

        if (collider.CompareTag("health"))
        {
            healItems++;
            collider.gameObject.SetActive(false);
        }

        if (collider.CompareTag("box"))
        {
            box = true;
            collider.gameObject.SetActive(false);
        }

        if (collider.CompareTag("DoorCard"))
        {
            key = true;
            collider.gameObject.SetActive(false);
        }

        if (collider.CompareTag("ammo"))
        {
            pistolAmmo += 30;
            collider.gameObject.SetActive(false);
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
                gunShot.Play();

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

            animator.SetBool("knock", true);
            footSteps.Play();
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
