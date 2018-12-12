using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    protected int hp = 100;
    protected int mp = 100;
    protected int attack;
    protected int defense;
    protected int level = 1;
    const int HPMAX = 100;
    const int MPMAX = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int HP
    {
        set
        {
            hp += value;
            if(hp < 0)
            {
                hp = 0;
            }
        }
        get { return hp; }
    }
    public int MP
    {
        set
        {
            mp += value;
            if (mp < 0)
            {
                mp = 0;
            }
        }
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

    public float HpRemaing()
    {
        return (float)hp / HPMAX;
    }

    public float MpRemaing()
    {
        return (float)mp / MPMAX;
    }
}
