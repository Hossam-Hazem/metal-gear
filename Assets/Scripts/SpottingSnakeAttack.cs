﻿using UnityEngine;
using System.Collections;

public class SpottingSnakeAttack : MonoBehaviour
{

    bool isDead = false;
    public GameObject bullet;
    float lastBulletWaitTime = 0f;
    public GameObject snake;
    int health = 100;

    Animator animator;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
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
                    Vector3 dir = (snake.transform.position - this.transform.position).normalized;
                    bulletCloneRigid.velocity = dir * 200f;
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
            }
        }
    }

    bool snakeSeen()
    {

        int visionField = 7;
        int veryCloseDistance = 1;
        float viewingAngle = 110f;

        RaycastHit hit;
        Vector3 rayDirection = snake.transform.position - transform.position;

        if (playerScript.isInBox && Physics.Raycast(transform.position, rayDirection, out hit) &&
            (hit.transform.gameObject.layer == LayerMask.NameToLayer("snake")) &&
            (hit.distance < veryCloseDistance))
        {
            return true;
        }

        if (playerScript.isInBox && (Vector3.Angle(rayDirection, transform.forward)) < ((viewingAngle / 2)) &&
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
