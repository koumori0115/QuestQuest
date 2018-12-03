using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {
    [SerializeField]
    PlayerStatus player;

    Slider hp;
	// Use this for initialization
	void Start () {
        hp = GetComponent<Slider>();
        hp.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
