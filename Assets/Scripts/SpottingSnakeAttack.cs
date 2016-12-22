using UnityEngine;
using System.Collections;

public class SpottingSnakeAttack : MonoBehaviour
{
    public bool isBoss = false;
    bool isDead = false;
    public GameObject bullet;
    float lastBulletWaitTime = 0f;
    public GameObject snake;
    public GameObject target;
    int health = 50;

    Animator animator;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator.SetBool("Rifle", true);
    }

    void Update()
    {

        if (health > 0)
        {
            if (snakeSeen())
            {
                navMeshAgent.Stop();
                transform.LookAt(snake.transform);
                animator.SetBool("Aim", true);
                GameObject currentLocation = new GameObject();
                currentLocation.transform.position = snake.transform.position;
                if (guardPath.destinationSnakeCurrentLocation != null)
                {
                    Destroy(guardPath.destinationSnakeCurrentLocation.gameObject);
                }
                guardPath.destinationSnakeCurrentLocation = currentLocation.transform;

                if (Time.time - lastBulletWaitTime > 0.5)
                {
                    animator.SetBool("Fire", true);

                    lastBulletWaitTime = Time.time;
                    GameObject bulletClone = (GameObject)Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
                    Rigidbody bulletCloneRigid = bulletClone.GetComponent<Rigidbody>();
                    bulletCloneRigid.isKinematic = false;
                    Vector3 dir = (target.transform.position - this.transform.position);
                    bulletCloneRigid.velocity = dir * 30f;
                    bulletClone.SetActive(true);
                    Destroy(bulletClone, 2.0f);
                }
            }
            else
            {
                animator.SetBool("Aim", false);
                navMeshAgent.Resume();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("snakeBullet") && health > 0)
        {
            health -= 20;

            if (health <= 0 && !isDead)
            {
                isDead = true;
                animator.SetBool("Ded", true);
                navMeshAgent.Stop();
                if (isBoss) {
                    playerScript.hasKilledBoss = true;
                }
            }
        }
    }

    bool snakeSeen()
    {

        int visionField = 7;
        int veryCloseDistance = 1;
        float viewingAngle = 90f;

        RaycastHit hit;
        Vector3 rayDirection = snake.transform.position - transform.position;

        if (!playerScript.isInBox && Physics.Raycast(transform.position, rayDirection, out hit) &&
            (hit.transform.gameObject.layer == LayerMask.NameToLayer("snake")) &&
            (hit.distance < veryCloseDistance))
        {
            return true;
        }

        if (!playerScript.isInBox && (Vector3.Angle(rayDirection, transform.forward)) < ((viewingAngle / 2)) &&
            Physics.Raycast(transform.position, rayDirection, out hit) &&
            hit.transform.gameObject.layer == LayerMask.NameToLayer("snake") &&
            (hit.distance < visionField))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
