using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_nonda : ItemsandChara
{
    PanelActive AnswerButton;
    Yesno answer;

    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒？ああ、最近噂の奴か。生憎だが俺は知らねぇぞ。" });
        set_nomalText(new string[] {"だから、俺は知らねぇって" });
        AnswerButton = GameObject.Find("GameManager").GetComponent<PanelActive>();
        answer = GameObject.Find("GameManager").GetComponent<Yesno>();
        //イベントフラグを作って一通り話しかけたら実はこいつが犯人でしたは面白いだろうか
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void eventResult()
    {
        base.eventResult();
        AnswerButton.AnswerActive();
        GameObject.Find("Chara").GetComponent<Player>().Serchflag(false);
        StartCoroutine("Select");


    }


    IEnumerator Select()
    {
        Debug.Log("aaa");
        while (answer.question == 0)
        {
            yield return null;
        }
        //1なら「はい」、2なら「いいえ」

        if (answer.question == 1)
        {
            
        }
        else
        {

        }
        answer.question = 0;
        AnswerButton.AnswerNonActive();
        GameObject.Find("Chara").GetComponent<Player>().Serchflag(true);

    }

}