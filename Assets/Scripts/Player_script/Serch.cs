using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Serch : MonoBehaviour {
    GameObject check;
    public Tilemap tilemap;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void serch(Vector3 serchposition)
    {
        try
        {
            if (GameObject.Find("GameManager").GetComponent<Item_List>().getItem(serchposition) != null)
            {
                GameObject.Find("GameManager").GetComponent<Item_List>().getItem(serchposition).information();
            }
        }
        catch
        {
            Debug.Log("error");
        }
    }
}
