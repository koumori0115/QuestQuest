using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattoleUI : MonoBehaviour {
    public GameObject BattleButton;
    public GameObject ItemButton;
    public GameObject EscapeButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonOff()
    {
        BattleButton.SetActive(false);
        ItemButton.SetActive(false);
        EscapeButton.SetActive(false);
    }

    public void ButtonOn()
    {
        BattleButton.SetActive(true);
        ItemButton.SetActive(true);
        EscapeButton.SetActive(true);
    }

    

}
