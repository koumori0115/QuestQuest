using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelActive: MonoBehaviour {
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject ItemPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuPanelStartActive()
    {
        if (GameObject.Find("Chara").GetComponent<Player>().step == Player.STEP.STOP)
        {
            GameObject.Find("Chara").GetComponent<Player>().step = Player.STEP.WAIT;
            MenuPanel.SetActive(true);
        }
    }
    public void MenuPanelReturnActive()
    {
        MenuPanel.SetActive(true);
    }
    public void MenuPanelNonActive()
    {

        MenuPanel.SetActive(false);
    }

    public void ItemPanelActive()
    {
        ItemPanel.SetActive(true);
    }
    public void ItemPanelNonActive()
    {
        ItemPanel.SetActive(false);
    }

    public void PlayerStart()
    {
        GameObject.Find("Chara").GetComponent<Player>().moveStart(0.1f);
    }
}
