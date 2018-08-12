using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ssd : MonoBehaviour {

    private bool played = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (played == false)
        {
            played = true;
            gameObject.GetComponent<AudioSource>().Play(0);
        }
    }
}
