using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_List : MonoBehaviour {
    List<ItemsandChara> list = new List<ItemsandChara>();

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public  void setItems(ItemsandChara item)
    {
        list.Add(item);
    }
    public void removeItems(ItemsandChara item)
    {
        list.Remove(item);
    }

    public ItemsandChara getItem(Vector3 p)
    {
        foreach(ItemsandChara i in list)
        {
            if(i.getPosition() == p)
            {
                return i;
            }
        }
        return null;
    }
}
