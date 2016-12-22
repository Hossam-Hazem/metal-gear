using UnityEngine;
using System.Collections;

public class camScript : MonoBehaviour {
    public AudioSource c1;
    public AudioSource c2;
    public AudioSource c3;
    public AudioSource doorOpen;


    // Use this for initialization
    void Start () {
        
        StartCoroutine(createSound(10));
        StartCoroutine(createDoorSound(15));


    }

    // Update is called once per frame
    void Update () {
	
	}

    private IEnumerator createSound(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            c1.Play();
        }
    }

    private IEnumerator createDoorSound(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            doorOpen.Play();
        }
    }
}
