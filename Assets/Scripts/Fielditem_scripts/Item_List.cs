using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_List : MonoBehaviour {
    static Item_List itemlist;
    List<ItemsandChara> list = new List<ItemsandChara>();
    List<GameObject> useItems = new List<GameObject>();
    GameObject itemPanel;
    private void Awake()
    {
        if (itemlist == null)
        {
            DontDestroyOnLoad(this);
            itemlist = this;
        }
        else
        {
            Destroy(this);
        }
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

    public void setUseItems(GameObject item)
    {
        useItems.Add(item);
        if(useItems.Count < 12)
        {
            Transform parentObject = GameObject.Find("Canvas").transform.Find("ItemPanel/Panel" + ((useItems.Count) % 12));
            try
            {
                Instantiate(item, parentObject.position, Quaternion.identity, parentObject);
            }
            catch
            {
                Debug.Log("生成ミス");
            }
        }
    }
    public void removeUseItems(GameObject item)
    {
        useItems.Remove(item);
    }

    
}
