using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taru : ItemsandChara
{
    [SerializeField] GameObject money;
    [SerializeField] string objectName;
	// Use this for initialization
	public override void Start () {
        base.Start();
        set_eventText(new string[] { objectName + "を手に入れた"});
        set_nomalText(new string[] { objectName + "を手に入れた" });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        GameObject.Find("GameManager").GetComponent<Item_List>().setUseItems(money);
    }
}
