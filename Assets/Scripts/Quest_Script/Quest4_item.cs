using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_item : ItemsandChara
{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒…悪い人ではないということしかわからないかな。", "少なくとも、普通の人にはいい印象みたいだね。" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "悪い人ではないみたいだよ。" });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        GameObject.Find("QuestFlag").GetComponent<Quest4_flag>().item = true;
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
