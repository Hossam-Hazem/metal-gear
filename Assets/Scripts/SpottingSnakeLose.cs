using UnityEngine;
using System.Collections;

public class SpottingSnakeLose : MonoBehaviour
{
    bool isDead = false;
    public int health = 20;
    public GameObject snake;
    Animator animator;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (health > 0 && snakeSeen())
        {
            //show loosing menu
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
