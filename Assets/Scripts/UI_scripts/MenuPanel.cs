using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuPanelActive()
    {
        if (GameObject.Find("Chara").GetComponent<Player>().step == Player.STEP.STOP)
        {
            GameObject.Find("Chara").GetComponent<Player>().step = Player.STEP.WAIT;
            gameObject.SetActive(true);
        }
    }
    public void MenuPanelNonActive()
    {
        GameObject.Find("Chara").GetComponent<Player>().moveStart(0.1f);
        gameObject.SetActive(false);
    }
}
