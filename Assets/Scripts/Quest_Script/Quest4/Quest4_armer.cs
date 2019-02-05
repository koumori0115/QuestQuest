using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_armer : ItemsandChara
{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒、ね。", "私たちにとってはいい話ではないけど、", "他の皆の間では", "悪い人ではないみたいよ？" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "他の皆の間では", "悪い人ではないみたいよ？" });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        GameObject.Find("QuestFlag").GetComponent<Quest4_flag>().armer = true;
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
