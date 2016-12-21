using UnityEngine;
using System.Collections;

public class SpottingSnakeLose : MonoBehaviour
{

    public int health = 20;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (health > 0)
        {
            RaycastHit raycastHit;
            Vector3 origin = transform.position;
            if (Physics.SphereCast(origin, 0.5f, transform.forward, out raycastHit, 5, 1 << 8))
            {
                //show loosing menu
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("bullet") && health > 0)
        {
            health -= 20;

            if (health <= 0)
            {
                animator.SetBool("Ded", true);
            }
        }
    }
}
