using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest2_syojo : ItemsandChara
{
    [SerializeField] GameObject money;
    [SerializeField] string objectName;

    bool yes =  false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "お兄さん、誰？ここのお山危ないよ。　…お母さんに言われて探しに来たの？" });
        //次に選択肢を出して、自分が何者か答えるかどうかで次が変わる。考えているのは答えないと不審者扱いされて少女が逃げて死ぬ。とか？現実はそれほど優しくないんだ
        //後はワードのメモ通りですかねぇ
        //set_nomalText(new string[] { "　" });

        if (yes == true) {
            patarn_y();
        }
        else {

        }

    }

    // Update is called once per frame
    void Update()
{

}

public override void eventResult()
{
    base.eventResult();
    event_flag = false;
    GameObject.Find("GameManager").GetComponent<Item_List>().setUseItems(money);
}

    public void patarn_y()
    {
        set_eventText(new string[] { "やっぱりそうなんだ。でもお母さんの為に薬草取ってこないといけないの。それを取ったら帰るから、お兄さん良かったらついてきて" });
    }


}