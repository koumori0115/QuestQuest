using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status {
    int gold;
    List<string> skills = new List<string>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int Gold
    {
        set { gold += value; }
        get { return gold; }
    }

    public void setSkill(string s)
    {
        skills.Add(s);
    }

    public string getSkill(int i)
    {
        return skills[i];
    }
}
