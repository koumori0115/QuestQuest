using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : UseItem {

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void ItemResult()
    {
        log.setInformation(new List<string>() { "どこかの鍵みたいだ", "持ち主はだれだろう？"});
        Debug.Log("BBB");
    }
}
