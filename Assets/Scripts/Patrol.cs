using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public Transform[] patrolPoints;
    public float moveSpeed;
    public GameObject deathParticles;
    public GameObject hurtSound;
    public Vector3 spawnPoint;
    private int currentPoint;

	// Use this for initialization
	void Start () {
        currentPoint = 0;
        //moveSpeed = 2.0f;
        transform.position = patrolPoints[0].position;
        GameObject obj = GameObject.FindGameObjectWithTag("Spawn");
        spawnPoint = obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () { //very basic waypoint system.
		if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity); //explody shit
            Instantiate(hurtSound, transform.position, Quaternion.identity); //oof
            other.transform.position = spawnPoint;
        }
    }
}
