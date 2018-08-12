using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private int ssd = 5;
    public float throw_power = 100;
    public GameObject ssd_go;
    public Transform spawner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (ssd > 0)
            {
                GameObject ssd_ins = Instantiate(ssd_go, spawner.position, spawner.transform.rotation);
                ssd_ins.GetComponent<Rigidbody>().AddForce(ssd_ins.transform.forward * throw_power);
            }
        }
    }
}
