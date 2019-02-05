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
        set_eventText(new string[] { "た、助けてください", "お願いします！"});
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
    public override void information()
    {
        if (event_flag)
        {
            if (i > 1)
            {
                Debug.Log(i);
                set_eventText(new string[] { "助けてって言ったでしょ！", "もう面倒くさい。", "お前から殺すわ" });
                log.setInformation(event_text, this);
            }
            else
            {
                i++;
                log.setInformation(event_text);
            }
        }
        else
        {
            log.setInformation(nomal_text);
        }
        
        
        
        
            
    }
}
