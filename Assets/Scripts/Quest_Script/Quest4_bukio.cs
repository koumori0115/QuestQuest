using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_bukio : ItemsandChara
{
    PanelActive AnswerButton;
    Yesno answer;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒？ああ、最近噂のね。", "俺たちは特に被害にあってないよ。", "他をあたってみてくれ。" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "被害にはあってないよ。" });
        AnswerButton = GameObject.Find("GameManager").GetComponent<PanelActive>();
        answer = GameObject.Find("GameManager").GetComponent<Yesno>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        GameObject.Find("QuestFlag").GetComponent<Quest4_flag>().waepon = true;
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
