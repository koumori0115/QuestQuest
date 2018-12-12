using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseItem : MonoBehaviour {
    protected Log log;
	// Use this for initialization
	public virtual void Start () {
        log = GameObject.Find("UI_scripts").GetComponent<Log>();
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public abstract void ItemResult();

}
