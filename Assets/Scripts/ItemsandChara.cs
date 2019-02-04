using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsandChara : MonoBehaviour {
    protected Log log;
    public bool event_flag = false;
    protected List<string> nomal_text = new List<string>();
    protected List<string> event_text = new List<string>();
    protected Vector3 zahyou;
    private void Awake()
    {
        zahyou = transform.position;
    }
    public virtual void Start () {
        zahyou = transform.position;
        log = GameObject.Find("GameManager").GetComponent<Log>();
        GameObject.Find("GameManager").GetComponent<Item_List>().setItems(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void information()
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
        nomal_text.Clear();
        foreach(string s in text)
        {
            nomal_text.Add(s);
        }
    }
    public void set_eventText(string[] text)
    {
        event_text.Clear();
        foreach (string s in text)
        {
            event_text.Add(s);
        }
    }

    public Vector3 getPosition()
    {
        return zahyou;
    }
    public virtual void eventResult() { }
}
