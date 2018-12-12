using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject textGameOver;     //ゲームオバーテキスト
    public GameObject textClear;        //クリアテキスト          //操作ボタン
    public GameObject textScoreNumber;
    public GameObject ClearButton;
    public GameObject GameOverButton;
    public GameObject TitleButton;
    private string g;
    private int ga = 1; 

    public enum GAME_MODE
    {              //ゲーム状態定義
        PLAY,                           //プレイ中
        CLEAR,                          //クリア
        GAMEOVER,                       //ゲームオバー
    }

    public GAME_MODE gameMode = GAME_MODE.PLAY; //ゲーム状態

    public AudioClip clearSE;
    public AudioClip gameoverSE;
    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        LoadG();
        gameMode = GAME_MODE.PLAY;
        audioSource = this.GetComponent<AudioSource>();
    }

    void GSave(string g) {
        PlayerPrefs.SetString(g, g);
        PlayerPrefs.Save();
    }

    int LoadG() {
        return PlayerPrefs.GetInt(g);
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameoverSE);
        
        textGameOver.SetActive(true);
        TitleButton.SetActive(true);
        GameOverButton.SetActive(true);
        gameMode = GAME_MODE.GAMEOVER;

    }

    public void GameClear()
    {
        audioSource.PlayOneShot(clearSE);
        g = g + 1;
        
        textClear.SetActive(true);
        TitleButton.SetActive(true);
        ClearButton.SetActive(true);
        gameMode = GAME_MODE.CLEAR;
        GSave(g);

    }

    public void LSecene1()
    {
        SceneManager.LoadScene("sin2");
    }

    public void LClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    public void LGameOver()
    {
        SceneManager.LoadScene("sin");
    }

    public void LGameOver2()
    {
        SceneManager.LoadScene("sin2");
    }

    public void LTitle()
    {
        SceneManager.LoadScene("title");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameMode == GAME_MODE.GAMEOVER)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("sin");
            }
         }

        
            if (gameMode == GAME_MODE.CLEAR)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                { 
                  SceneManager.LoadScene("sin2");
                        
                }
            }
        
    */
    }
    
    

}
