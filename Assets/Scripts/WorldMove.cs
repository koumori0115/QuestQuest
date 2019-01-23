using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quest1()
    {
        SceneManager.LoadScene("Quest1");
    }

    public void Quest2()
    {
        SceneManager.LoadScene("Quest2");
    }

    public void Quest3()
    {
        SceneManager.LoadScene("Quest3");
    }

    public void Quest4()
    {
        SceneManager.LoadScene("Quest4");
    }

}
