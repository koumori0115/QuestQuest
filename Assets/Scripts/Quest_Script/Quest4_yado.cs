using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_yado : ItemsandChara
{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒ね、お客さんの話で聞いたことあるわ。", "その人、貧しい子供に盗んだお金を渡しているみたいよ。" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "お客さん以外に話すことはありません。" });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        event_flag = false;
        set_nomalText(new string[] { "私が聞いたのはそれぐらいかしら。" });
        GameObject.Find("QuestFlag").GetComponent<Quest4_flag>().yado = true;
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
