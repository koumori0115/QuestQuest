using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest1_enemy : MonoBehaviour {

    public GameObject text1;     
    public GameObject text2;
    public GameObject text3;
    private int count;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

    }


    //プレイヤー触れたら
    void OnTriggerEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //count += 1;
            text1.SetActive(true);
        }

        if (col.gameObject.tag == "Player" && count == 1)
        {
            count += 1;
            text2.SetActive(true);
        }

        if (col.gameObject.tag == "Player" && count == 2)
        {
            count += 1;
            text3.SetActive(true);
        }
    }

    //オブジェクトが離れたタイミング
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
        }

    }

}
