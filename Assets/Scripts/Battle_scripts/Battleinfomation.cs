using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleinfomation : MonoBehaviour {
    Dictionary<int, string[]> battle = new Dictionary<int, string[]>();
    Dictionary<int, string[]> item = new Dictionary<int, string[]>();
    Dictionary<int, string[]> escape = new Dictionary<int, string[]>();
    int bi = 0;
    int ii = 0;
    int ei = 0;
    int damage = 0;
    BattleLog log;
	// Use this for initialization
	void Start () {
        log = GetComponent<BattleLog>();
        BattleSerif();
        ItemSerif();
        EscapeSerif();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void BattleSerif()
    {
        damage = Random.Range(20, 33);
        battle.Add(0, new string[] { "あなたは吸血鬼に攻撃をした。", "0", "吸血鬼たちの攻撃。", damage + "" });
        damage = Random.Range(20, 33);
        battle.Add(1, new string[] { "あなたは吸血鬼に攻撃をした。", "0", "吸血鬼たちの攻撃。", damage + "", "「これを使って！！負けないで」", "女性から十字架を投げ渡された"});
        battle.Add(2, new string[] { ""});
    }
    void ItemSerif()
    {
        item.Add(0, new string[] { "しかし何も持っていなかった。" });
        item.Add(1, new string[] { ""});
        item.Add(2, new string[] { ""});
    }
    void EscapeSerif()
    {
        escape.Add(0, new string[] { "あなたは逃げようとした。", "「頑張って、負けないで！」", "あなたは逃げられなかった……" });
        escape.Add(1, new string[] { "あなたは逃げようとした。", "ねえ、今逃げようとした？そんなわけないよね？ね？」", "あなたは逃げられなかった……"});
        escape.Add(2, new string[] { "あなたは逃げようとした。", "「ああ、もう]", "「ここまで私が応援してあげたのに逃げようとするなんて」", "「もうあなたはいらないわ」", "999のダメージ", "あなたは死んでしまった。", "end"});
    }
    public void Battleinfo()
    {
        log.setInformation(battle[bi]);
        bi++;
        if(bi == 1)
        {
            ii++;
        }
    }

    public void Iteminfo()
    {
        log.setInformation(item[ii]);
    }

    public void Escapeinfo()
    {
        log.setInformation(escape[ei]);
        ei++;
    }
}
