using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    protected int hp;
    protected int mp;
    protected int attack;
    protected int defense;
    protected int level = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int HP
    {
        set { hp += value; }
        get { return hp; }
    }
    public int MP
    {
        set { mp += value; }
        get { return mp; }
    }
    public int Attack
    {
        set { attack += value; }
        get { return attack; }
    }
    public int Defense
    {
        set { defense = value; }
        get { return defense; }
    }
    public int Level
    {
        set { level += value; }
        get { return level; }
    }
}
