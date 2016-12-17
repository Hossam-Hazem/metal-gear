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
    bool hasReachedSnake = false;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
        agent.SetDestination(destination1.position);
		agent.speed = agentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
		anim.SetFloat ("Forward", agent.desiredVelocity.magnitude/animationSpeedMultiplier);
        if (destinationSnakeCurrentLocation != null)
        {
            agent.SetDestination(destinationSnakeCurrentLocation.position);
            if (destinationSnakeCurrentLocation.position.x == this.transform.position.x && destinationSnakeCurrentLocation.position.z == this.transform.position.z)
            {
                destinationSnakeCurrentLocation = null;
            }
        }
        else
        {
            if (!hasReachedTarget1)
            {
                agent.SetDestination(destination1.position);
                if (destination1.position.x == this.transform.position.x && destination1.position.z == this.transform.position.z)
                {
                    hasReachedTarget1 = true;
                }
            }
            else
            {
                agent.SetDestination(destination2.position);
                if (destination2.position.x == this.transform.position.x && destination2.position.z == this.transform.position.z)
                {
                    hasReachedTarget1 = false;
                }
            }
        }

    }
}
