using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerl : ItemsandChara {

    [SerializeField] GameObject money;
    [SerializeField] string objectName;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "お兄さん、誰？ここのお山危ないよ" });
        //次に選択肢を出して、自分が何者か答えるかどうかで次が変わる。考えているのは答えないと不審者扱いされて少女が逃げて死ぬ。とか？現実はそれほど優しくないんだ
        //後はワードのメモ通りですかねぇ
        set_nomalText(new string[] { objectName + "を手に入れた" });
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
}
