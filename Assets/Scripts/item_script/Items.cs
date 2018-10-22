using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour {
    Log log;
    public bool event_flag = false;
    List<string> nomal_text = new List<string>();
    List<string> event_text = new List<string>();

	public virtual void Start () {
        log = GameObject.Find("UI_scripts").GetComponent<Log>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void information()
    {
        if (event_flag)
        {
            log.setInformation(event_text);
        }
        else
        {
            log.setInformation(nomal_text);
        }
    }

    public void set_nomalText(string[] text)
    {
        foreach(string s in text)
        {
            nomal_text.Add(s);
        }
    }
    public void set_eventText(string[] text)
    {
        foreach (string s in text)
        {
            nomal_text.Add(s);
        }
    }
}
