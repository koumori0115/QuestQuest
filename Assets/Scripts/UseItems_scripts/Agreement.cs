﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agreement : UseItem {

	// Use this for initialization
    public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void ItemResult()
    {
        
        Debug.Log("aaa");
    }
}
