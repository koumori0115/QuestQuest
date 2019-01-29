using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Log : MonoBehaviour {
    
    public List<string> information = new List<string>();
    [SerializeField] Text uiText;   // uiTextへの参照
    [SerializeField] GameObject scroll;
    [SerializeField] GameObject menuButton;
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;       // 表示中の文字数
    public bool saisei = false;
    //itemlogが0以外だったらitemを参照したlogになる
    int itemlog = 0;
    

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (saisei)
        {
            // 文章の表示完了 / 未完了
            if (IsDisplayComplete())
            {
                //最後の文章ではない & ボタンが押された
                if (information.Count > 0 && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0)))
                {
                    SetSentence();
                }
                     
                else if (information.Count == 0 && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0)))
                {
                    uiText.text = "";
                    scroll.SetActive(false);
                    menuButton.SetActive(true);
                    if (itemlog == 0)
                    {
                        
                    }
                    else
                    {
                        itemlog = 0;
                    }
                    saisei = false;

                }
            }
            else
            {
                //ボタンが押された
                if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0)))
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

    public void Master_Log()
    {

    }

    void SetSentence()
    {
        currentSentence = information[0];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        Master_Log();
        information.RemoveAt(0);
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }

    public void setInformation(List<string> information)
    {
        if (!saisei)
        {
            menuButton.SetActive(false);
            scroll.SetActive(true);
            saisei = true;
            foreach (string s in information)
            {
                this.information.Add(s);
            }
        }
    }

    public void setInformation(List<string> information, int i)
    {
        if (!saisei)
        {
            menuButton.SetActive(false);
            scroll.SetActive(true);
            saisei = true;
            foreach (string s in information)
            {
                this.information.Add(s);
            }
        }
        itemlog = i;
    }


}
