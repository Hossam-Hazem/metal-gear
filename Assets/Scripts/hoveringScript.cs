using UnityEngine;
using System.Collections;

public class hoveringScript : MonoBehaviour {
    public AudioSource hovering;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hover()
    {
        hovering.Play();

    }
}
