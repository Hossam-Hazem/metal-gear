using UnityEngine;
using System.Collections;

public class guardPath : MonoBehaviour
{

    private NavMeshAgent agent;
    Animator anim;
    public Transform destination1;
    public Transform destination2;
    bool hasReachedTarget1 = false;
    public float animationSpeedMultiplier;
    public float agentSpeed;

    public static Transform destinationSnakeCurrentLocation;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(destination1.position);
        agent.speed = agentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Forward", agent.desiredVelocity.magnitude / animationSpeedMultiplier);
        if (destinationSnakeCurrentLocation != null)
        {
            agent.SetDestination(destinationSnakeCurrentLocation.position);
            if (Vector3.Distance(destinationSnakeCurrentLocation.position, transform.position) < 0.5f)
            {
                Destroy(destinationSnakeCurrentLocation.gameObject);
                destinationSnakeCurrentLocation = null;
            }
        }
        else
        {
            if (!hasReachedTarget1)
            {
                agent.SetDestination(destination1.position);
                if (Vector3.Distance(destination1.position, transform.position) < 0.5f)
                {
                    hasReachedTarget1 = true;
                }
            }
            else
            {
                agent.SetDestination(destination2.position);
                if (Vector3.Distance(destination2.position, transform.position) < 0.5f)
                {
                    hasReachedTarget1 = false;
                }
            }
        }

    }
}
