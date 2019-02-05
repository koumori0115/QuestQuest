using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4_flag : MonoBehaviour {

    public bool item = false;
    public bool waepon = false;
    public bool armer = false;
    public bool yado = false;
    public bool child1 = false;
    public bool child2 = false;
    public bool child3 = false;
    [SerializeField] GameObject childs;
    bool loopOf1 = false;
    bool loopOf2 = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(item && waepon && armer && yado && !loopOf1)
        {
            Instantiate(childs);
            loopOf1 = true;
        }
        else if(child1 && child2 && child3 && !loopOf2)
        {
            GameObject.Find("nondakure").GetComponent<Quest4_nonda>().allFlag = true;
            GameObject.Find("nondakure").GetComponent<Quest4_nonda>().set_eventText(new string[] { "えっ、", "泥棒が俺じゃないかって？" });
            loopOf2 = true;
        }
	}
}
