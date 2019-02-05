using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_flag : MonoBehaviour {

    public bool item = false;
    public bool waepon = false;
    public bool armer = false;
    public bool yado = false;
    bool loopOf = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(item && waepon && armer && yado && !loopOf)
        {
            loopOf = true;
        }
        else
        {
            Debug.Log(item);
            Debug.Log(waepon);
            Debug.Log(armer);
            Debug.Log(yado);
            Debug.Log(loopOf);
        }
	}
}
