using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_nonda : ItemsandChara
{
    List<string> selectText;
    PanelActive AnswerButton;
    Yesno answer;
    public bool allFlag = false;
    int count = 0;

    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒？ああ、最近噂の奴か。", "生憎だが俺は知らねぇぞ。" });
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
        GameObject.Find("Chara").GetComponent<Player>().Stopflag(true);
        base.eventResult();
        if (allFlag && count == 0)
        {
            count++;
            set_eventText(new string[] {"いやだからほんとに", "俺じゃないって言ってるだろ？" });

        }
        else if (count == 1)
        {
            count++;
            set_eventText(new string[] { "はぁ、", "こんだけ俺に話しかけてくるってことは", "もうばれてるってことか。", "いつかはこんな日が来ると思ってた。", "抵抗はしねぇ","ただ子供たちは許してやってくれ", "捕まえますか？" });
        }
        else if (count == 2)
        {
            count++;
            AnswerButton.AnswerActive();
            GameObject.Find("Chara").GetComponent<Player>().Serchflag(false);
            StartCoroutine("Select");
        }
        else if()


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
            //このクラスはnomal_textを選択後のテキストとして使う
            set_nomalText(new string[] {"あなたは泥棒を捕まえた", "", "" });
            
        }
        else
        {
            //このクラスはnomal_textを選択後のテキストとして使う
            set_nomalText(new string[] {"あなたは泥棒を捕まえないことにした", "ありがてえ、", "これでこれからも", "あいつらの世話をしてやれる", "じゃあ代わりに捕まってくれや", "彼は大声で言った。", "こいつが例の泥棒だったんだ！！", "みんな捕まえてくれ！！" });
        }

        log.setInformation(nomal_text);
        answer.question = 0;
        AnswerButton.AnswerNonActive();
        GameObject.Find("Chara").GetComponent<Player>().Serchflag(true);

    }

}