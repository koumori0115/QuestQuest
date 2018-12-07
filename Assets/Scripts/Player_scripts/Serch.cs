using UnityEngine;
using System.Collections;

public class Serch : MonoBehaviour
{

    TapObserver tapObserver;

    void Start()
    {
        tapObserver = GameObject.Find("GameManager").GetComponent<TapObserver>();
        tapObserver.callbackFunction = GameObject.Find("Chara").GetComponent<Player>().onClick;
        tapObserver.x = 0;
        tapObserver.y = 0;
        tapObserver.w = Screen.currentResolution.width;
        tapObserver.h = Screen.currentResolution.height / 2;
    }

}
