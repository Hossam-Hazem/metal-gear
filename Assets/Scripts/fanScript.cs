
using UnityEngine;
using System.Collections;

public class fanScript : MonoBehaviour {
   public GameObject circle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        circle.transform.Rotate(0f, 02f, 0);
	}
}
