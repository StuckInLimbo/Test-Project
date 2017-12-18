using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 60, 20), "Main Menu"))
            SceneManager.LoadScene(0);
        //if (GUI.Button(new Rect(0, 25, 60, 20), "Level 2"))
        //    SceneManager.LoadScene(1);
        //if (GUI.Button(new Rect(0, 50, 60, 20), "Quit"))
        //{
        //    Application.Quit();
        //    print("QUITTING GAME");
        //}     
    }
}
