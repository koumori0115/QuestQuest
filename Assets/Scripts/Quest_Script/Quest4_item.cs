using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_item : ItemsandChara
{
    [SerializeField] GameObject AnswerButton;
    [SerializeField] GameObject answer;

    bool yes = false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒…悪い人ではないということしかわからないかな。少なくとも、普通の人にはいい印象みたいだね。" });
        //Wordの目も見てどうぞ
        set_nomalText(new string[] { "悪い人ではないみたいだよ。" });

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
