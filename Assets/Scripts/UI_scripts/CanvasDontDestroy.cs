using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDontDestroy : MonoBehaviour {
    static CanvasDontDestroy canvas;
    private void Awake()
    {
        if(canvas == null)
        {
            DontDestroyGameObject.DontDestroyOnLoad(gameObject);
            canvas = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
