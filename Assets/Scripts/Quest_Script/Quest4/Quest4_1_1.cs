﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_1_1 : ItemsandChara
{
    [SerializeField] GameObject money;
    [SerializeField] string objectName;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //set_eventText(new string[] { "" });
    
        set_nomalText(new string[] { "泥棒の事、お願いね。" });
    }

    // Update is called once per frame
    void Update()
    {

    }

}