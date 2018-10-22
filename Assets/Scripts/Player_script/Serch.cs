using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Serch : MonoBehaviour {
    GameObject check;
    public Tilemap tilemap;
    // Use this for initialization
    void Start () {
        Debug.Log(tilemap.GetSprite(new Vector3Int(-9, 13, 0)));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void serch(Vector3Int serchposition)
    {
        if(tilemap.GetInstantiatedObject(serchposition) != null)
            Debug.Log(tilemap.GetInstantiatedObject(serchposition));
    }
}
