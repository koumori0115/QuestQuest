using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_bukio : ItemsandChara
{
    PanelActive AnswerButton;
    Yesno answer;

    bool yes = false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒？ああ、最近噂のね。俺たちは特に被害にあってないよ。他をあたってみてくれ。" });
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
        AnswerButton.AnswerActive();
        GameObject.Find("Chara").GetComponent<Player>().Serchflag(false);
        StartCoroutine("Select");


    }
  

    IEnumerator Select()
    {
        Debug.Log("aaa");
        while (answer.question == 0) {
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
