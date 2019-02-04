﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_armer : ItemsandChara
{
    [SerializeField] GameObject AnswerButton;
    [SerializeField] GameObject answer;

    bool yes = false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒、ね。私たちにとってはいい話ではないけど、他の皆の間では悪い人ではないみたいよ？" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "他の皆の間では悪い人ではないみたいよ？" });

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
