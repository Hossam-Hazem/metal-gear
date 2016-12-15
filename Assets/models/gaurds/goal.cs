using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {
	private NavMeshAgent agent;
	public Transform destination;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination (destination.position);
	}

	// Update is called once per frame
	void Update () {
	}
}
