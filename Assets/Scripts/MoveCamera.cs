using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public float smooth = 2.5F;
    public float tiltAngle = 90.0F;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // zoom in and out
        {
            //position.y += Input.GetAxis("Mouse ScrollWheel");
            if(transform.position.y > 5 && transform.position.y < 50)
                transform.position = transform.position + new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * 10 * -1, 0);
            else if (transform.position.y <= 5)
                transform.position = transform.position + new Vector3(0, 1, 0); //prevents locking
            else if (transform.position.y >= 50)
                transform.position = transform.position + new Vector3(0, -1, 0); //prevents locking
        }
        if (true == false)
        {
            if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f) //disable for now, needs tweaking
            {
                float tiltAroundZ, tiltAroundY, tiltAroundX; //vars for all rotation, will cut later
                tiltAroundX = transform.rotation.x; //default
                tiltAroundZ = Input.GetAxis("Mouse Y") * tiltAngle;
                tiltAroundY = Input.GetAxis("Mouse X") * tiltAngle; // not sure if Im going to use or not
                Quaternion target = Quaternion.Euler(90, 0, tiltAroundZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
        }
        //if (Input.GetKeyDown("e"))
        //{

        //}
        //if (Input.GetKeyDown("q"))
        //{

        //}
    }
}
