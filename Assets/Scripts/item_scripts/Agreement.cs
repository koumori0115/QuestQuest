using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agreement : UseItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void ItemResult()
    {
        base.ItemResult();
        Debug.Log("aaa");
    }
}
