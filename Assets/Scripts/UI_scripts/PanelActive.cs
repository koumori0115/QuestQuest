using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelActive: MonoBehaviour {
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject ItemPanel;
    [SerializeField] GameObject AnswerButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuPanelActive()
    {
        if (GameObject.Find("GameManager").GetComponent<Log>().saisei == false)
        {
            MenuPanel.SetActive(true);
        }
        
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
        if (GameObject.Find("GameManager").GetComponent<Log>().saisei == false)
        {
            ItemPanel.SetActive(false);
        }
        
    }
    public void AnswerActive()
    {
        AnswerButton.SetActive(true);
    }
    public void AnswerNonActive()
    {
        AnswerButton.SetActive(false);
    }
}
