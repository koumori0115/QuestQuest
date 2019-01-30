using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1_syonin : ItemsandChara
{

    int i = 0;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "貴様も奴らの仲間か！", "ならば叩き潰すまでッ！！" });
        set_nomalText(new string[] { "" });


    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void eventResult()
    {
        base.eventResult();
        Debug.Log("eventresult");
    }

    
    public override void information()
    {
        if (event_flag)
        {
            log.setInformation()
        }
    }
    
}
