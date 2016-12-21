using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {
    public GameObject ending;
    public GameObject target;
    public GameObject names;

    public GameObject cat;
    public GameObject intro;
    public GameObject final;
    public GameObject final2;



    private float speed = 0.4f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        names.transform.Translate(0, speed, 0);
        cat.transform.Translate(0, speed, 0);
        intro.transform.Translate(0, speed, 0);
        final.transform.Translate(0, speed, 0);
        final2.transform.Translate(0, speed, 0);



        if (ending.transform.position[1] < target.transform.position[1])
        {
            ending.transform.Translate(0, speed, 0);
        }
	}
}
