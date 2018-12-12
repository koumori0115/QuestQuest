using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1_enemy : ItemsandChara
{

    int i = 0;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "た、助けてください！" });
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
        base.information();
        if (i == 0)
        {
            set_eventText(new string[] { "た、助けてください！" });
            i++;
        }
        else if (i == 1)
        {
            set_eventText(new string[] { "助けてって言ってるでしょ！？もういいわよアンタから叩き切ってやるッ！！" });
        }
    }
}
