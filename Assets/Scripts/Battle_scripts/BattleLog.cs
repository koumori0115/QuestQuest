using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleLog : MonoBehaviour
{

    public List<string> information = new List<string>();
    [SerializeField] Text uiText;   // uiTextへの参照
    [SerializeField] GameObject scroll;
    [SerializeField] BattoleUI button;
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;       // 表示中の文字数
    bool turn = false;
    bool saisei = false;
    bool efecton = false;
    SceneMove scene = new SceneMove();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (saisei)
        {
            // 文章の表示完了 / 未完了
            if (IsDisplayComplete())
            {
                if (efecton)
                {
                    //エフェクトを入れる
                    StartCoroutine("Efect");
                    efecton = false;
                }
                //最後の文章ではない & ボタンが押された
                if (information.Count > 0 && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0)))
                {
                    SetSentence();
                }

                else if (information.Count == 0 && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0)))
                {
                    uiText.text = "";
                    scroll.SetActive(false);
                    button.ButtonOn();
                    saisei = false;

                }
            }
            else
            {
                //ボタンが押された
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0))
                {
                    timeUntilDisplay = 0; //※1
                }
            }


            //表示される文字数を計算
            int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
            //表示される文字数が表示している文字数と違う
            if (displayCharCount != lastUpdateCharCount)
            {
                uiText.text = currentSentence.Substring(0, displayCharCount);
                //表示している文字数の更新
                lastUpdateCharCount = displayCharCount;
            }
        }

    }


    void SetSentence()
    {
        currentSentence = information[0];
        if (currentSentence.Equals("end"))
        {
            scene.GameOver();
        }
        if (Check(currentSentence))
        {

            currentSentence += "のダメージ";
            efecton = true;
        }
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        information.RemoveAt(0);
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }

    public void setInformation(string[] information)
    {
        if (!saisei)
        {
            scroll.SetActive(true);
            saisei = true;
            foreach (string s in information)
            {
                this.information.Add(s);
            }
        }
    }

    bool Check(string str)
    {
        if (str.Equals(""))
        {
            return false;
        }
        foreach (char c in str)
        {
            //数字以外の文字が含まれているか調べる
            if (c < '0' || '9' < c)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator Efect()
    {
        Debug.Log("aaa");
        if (turn)
        {
            //プレイヤーのＨＰ減算処理、エフェクト
        }
        else
        {
            //敵のダメージエフェクト
        }
        turn = !turn;
        saisei = false;
        yield return new WaitForSeconds(2);
        saisei = true;
        Debug.Log("BBB");
    }

}
