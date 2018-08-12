using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour {

    private float minX = -60f;
    private float maxX = 60f;
    private float minY = -360f;
    private float maxY = 360f;
    private float rotationY;
    private float rotationX;

    [Range(0.0f, 40.0f)]
    public float sensitivity = 15f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, minX, maxX);

        //transform.localEulerAngles = new Vector3(0, rotationY, 0);
        Camera.main.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            gameObject.GetComponent<Camera>().fieldOfView = 30;
        } else { 
            gameObject.GetComponent<Camera>().fieldOfView = 60;
        }
    }
}
