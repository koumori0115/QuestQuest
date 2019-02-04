using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_yado : ItemsandChara
{
    [SerializeField] GameObject AnswerButton;
    [SerializeField] GameObject answer;

    bool yes = false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒ね、お客さんの話で聞いたことあるわ。その人、貧しい人に盗んだお金を渡しているみたいよ。" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "私が聞いたのはそれぐらいかしら。" });

        if (yes == true)
        {

        }
        else
        {

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        AnswerButton.SetActive(true);
        while (answer.GetComponent<Yesno>().question == 0) { };
        //trueなら「はい」、falseなら「いいえ」
        if (answer.GetComponent<Yesno>().question == 1)
        {

        }
        else
        {

        }
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
