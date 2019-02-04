using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1_syonin2 : ItemsandChara
{

    int i = 0;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "", "" });
        set_nomalText(new string[] { "" });


    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void eventResult()
    {
        base.eventResult();
    }


}
