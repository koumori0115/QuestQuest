using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basis : ItemsandChara {
    [SerializeField] GameObject eventObject;
    [SerializeField] string ObjectName = "コイン";
	// Use this for initialization
	public override void Start () {
        base.Start();
        set_eventText(new string[]{"水の入った坪だ", "水の底で何かが光っている", ObjectName + "を手に入れた"});
        set_nomalText(new string[] { "水の入った坪だ" });
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        GameObject.Find("GameManager").GetComponent<Item_List>().setUseItems(eventObject);
        Debug.Log("eventresult");
    }

}
