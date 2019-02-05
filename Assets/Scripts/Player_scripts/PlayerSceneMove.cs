using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneMove : MonoBehaviour {

    List<string> wall;
	// Use this for initialization
	void Start () {
        wall = new List<string>();
        wall.Add("ただいまこちらは通ることができません");
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameObject.Find("GameManager").GetComponent<Log>().setInformation(wall);
        }
    }
}
