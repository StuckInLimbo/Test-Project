using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
