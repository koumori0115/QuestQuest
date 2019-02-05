using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_poorChild3 : ItemsandChara
{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "たまにふかふかのベッドでも", "ねむらせてくれるよねー。", "つぎいつかなぁ？" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "ふかふかのベッド♪","ふかふかのベッド♪" });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        GameObject.Find("QuestFlag").GetComponent<Quest4_flag>().child3 = true;
    }

    public override void information()
    {
        if (event_flag)
        {
            log.setInformation(event_text, this);
        }
        else
        {
            log.setInformation(nomal_text);
        }
    }
}
