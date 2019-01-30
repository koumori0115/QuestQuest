using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_nonda : ItemsandChara
{
    [SerializeField] GameObject money;
    [SerializeField] string objectName;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        set_eventText(new string[] { "泥棒？ああ、最近噂の奴か。生憎だが俺は知らねぇぞ。" });
        set_nomalText(new string[] {"だから、俺は知らねぇって" });
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