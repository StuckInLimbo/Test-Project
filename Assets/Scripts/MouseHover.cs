using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {
    private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
        rend.material.color = Color.black;
    }
	
    private void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.black;
    }

}
