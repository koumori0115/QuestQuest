using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3_mafia : ItemsandChara
{
    [SerializeField] GameObject AnswerButton;
    [SerializeField] GameObject answer;

    bool yes = false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "こんな所にお客さんとは珍しいな。何か用かい？ いや、久々のお客さんだ。何かもてなしの料理を作ろう" });
        //Wordの目も見てどうぞ
        //set_nomalText(new string[] { "　" });

        if (yes == true)
        {
            patarn_y();
        }
        else
        {
            patarn_n();
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
    public void patarn_y()
    {
        set_eventText(new string[] { "そうかい、それは残念だ。まあゆっくりしていってくれ。" });
        log.setInformation(event_text);
    }

    public void patarn_n()
    {
        set_eventText(new string[] { "そうかそうか。なら、今から作るから少し待ってくれ" });
        log.setInformation(event_text);
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
