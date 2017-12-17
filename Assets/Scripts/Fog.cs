using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {
    public bool active;
    public int areaNum;

    private Renderer rend;
    private GameObject player;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        PlayerMovement pm;
        pm = player.GetComponent<PlayerMovement>();
        if (pm.areaNum != areaNum)
        {
            //idk
        }
        isActive();
	}

    private void isActive()
    {
        if (active)
            rend.enabled = false;
        else
            rend.enabled = true;
        //player is in same area, therefor active
    }
}
