using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basis : Items {

	// Use this for initialization
	public override void Start () {
        base.Start();
        set_eventText(new string[]{"水の入った坪だ", "水の底で何かが光っている","コインを手に入れた"});
        set_nomalText(new string[] { "水の入った坪だ" });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
