using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPbar : MonoBehaviour
{
    [SerializeField]
    PlayerStatus player;

    Slider mp;
    // Use this for initialization
    void Start()
    {
        mp = GetComponent<Slider>();
        mp.value = 1;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
