using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject teleportSpot;
    public int ID;
	// Use this for initialization
	void Start () {
        GameObject[] tpSpots;
        tpSpots = GameObject.FindGameObjectsWithTag("Teleporter");
        for(int i = 0; i < tpSpots.Length; i++)
        {
            if (ID != tpSpots[i].GetComponent<Teleport>().ID)
                teleportSpot = tpSpots[i].transform.GetChild(0).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
