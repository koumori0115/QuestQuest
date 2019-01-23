using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
