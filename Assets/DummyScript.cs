﻿using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			anim.SetBool ("Pistol", true);
            anim.SetBool("Aim", true);
		}
	}
}