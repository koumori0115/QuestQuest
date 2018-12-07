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
        log.setInformation(new string[] { "相手は吸血鬼だった！！", "あなたはどうする？"});
        BattleSerif();
        ItemSerif();
        EscapeSerif();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void BattleSerif()
    {
        damage = Random.Range(25, 33);
        battle.Add(0, new string[] { "あなたは吸血鬼に攻撃をした。", "0", "吸血鬼たちの攻撃。", damage + "" });
        damage = Random.Range(25, 33);
        battle.Add(1, new string[] { "あなたは吸血鬼に攻撃をした。", "0", "吸血鬼たちの攻撃。", damage + "", "「これを使って！負けないで」", "女性から十字架を投げ渡された。"});
        damage = Random.Range(25, 33);
        battle.Add(2, new string[] { "あなたは吸血鬼に攻撃をした。", "0", "吸血鬼たちの攻撃。", damage + "", "「はやく、十字架を使って！！」"});
        damage = Random.Range(25, 33);
        battle.Add(3, new string[] { "あなたは吸血鬼に攻撃をした。", "0", "吸血鬼たちの攻撃。", damage + "", "あなたは死んでしまった。", "end"});
        battle.Add(4, new string[] { "あなたは吸血鬼に攻撃をした。", "100", "吸血鬼たちの攻撃。", "0" });
        battle.Add(5, new string[] { "あなたは吸血鬼に攻撃をした。", "100", "kill", "吸血鬼たちは倒れた。", "「ありがとうございます」", "999", "「あいつら殺すの面倒くさかったので助かりました」", "あなたは死んでしまった。", "end" });

    }
    void ItemSerif()
    {
        item.Add(0, new string[] { "しかし何も持っていなかった。" });
        item.Add(1, new string[] { "十字架を使った。", "吸血鬼たちが苦しみだした。"});
        item.Add(2, new string[] { "十字架はもう使っている。"});
    }
    void EscapeSerif()
    {
        escape.Add(0, new string[] { "あなたは逃げようとした。", "「頑張って、負けないで！」", "あなたは逃げられなかった……" });
        escape.Add(1, new string[] { "あなたは逃げようとした。", "「ねえ、今逃げようとした？そんなわけないよね？ね？」", "あなたは逃げられなかった……"});
        escape.Add(2, new string[] { "あなたは逃げようとした。", "「ああ、もう」", "「ここまで私が応援してあげたのに逃げようとするなんて」", "「もうあなたはいらないわ」", "999のダメージ", "あなたは死んでしまった。", "end"});
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
        if(ii == 1)
        {
            ii++;
            bi = 4;
        }
    }

    public void Escapeinfo()
    {
        log.setInformation(escape[ei]);
        ei++;
    }
}
