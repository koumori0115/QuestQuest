using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yesno : MonoBehaviour {

    enum Answer { 
        YES = 1,
        NO = 2,
        WAIT = 0,
    };
    public int question = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AnswerYes()
    {
        question = 1;
    }
    public void AnswerNo()
    {
        question = 2;
    }
    public int GetQuestion()
    {
        return question;
    }
}
