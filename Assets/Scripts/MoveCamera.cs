using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            //position.y += Input.GetAxis("Mouse ScrollWheel");
            if(transform.position.y > 5 && transform.position.y < 50)
                transform.position = transform.position + new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * 10 * -1, 0);
            else if (transform.position.y <= 5)
                transform.position = transform.position + new Vector3(0, 1, 0);
            else if (transform.position.y >= 50)
                transform.position = transform.position + new Vector3(0, -1, 0);
        }
    }
}
