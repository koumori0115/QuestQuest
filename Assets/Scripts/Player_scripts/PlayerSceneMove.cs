using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "SE")
        {
            SceneManager.LoadScene("mainmap_SE");
            return;
        }
        if (collision.gameObject.tag == "SW")
        {
            SceneManager.LoadScene("mainmap_SW");
            return;
        }
        if (collision.gameObject.tag == "NE")
        {
            SceneManager.LoadScene("mainmap_NE");
            return;
        }
        if (collision.gameObject.tag == "NW")
        {
            SceneManager.LoadScene("mainmap_NW");
            return;
        }
    }
    }
