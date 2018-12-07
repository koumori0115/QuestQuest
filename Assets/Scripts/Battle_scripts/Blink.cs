using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour {
    public float speed = 2.0f;

    Text text;
    Image image;
    float time;
    Color motocolor;
    bool saisei = false;

    enum ObjType
    {
        TEXT,
        IMAGE
    };
    ObjType thisObjType = ObjType.TEXT;
	// Use this for initialization
	void Start () {
        if (this.gameObject.GetComponent<Image>())
        {
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
            motocolor = image.color;
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
            motocolor = text.color;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (saisei)
        {
            if (thisObjType == ObjType.IMAGE)
            {
                image.color = GetAlphaColor(image.color);
            }
            else if (thisObjType == ObjType.TEXT)
            {
                text.color = GetAlphaColor(text.color);
            }

        }
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }

    public void SaiseiChange()
    {
        saisei = !saisei;
        if (saisei == false)
        {
            if (thisObjType == ObjType.IMAGE)
            {
                image.color = motocolor;
            }
            else if (thisObjType == ObjType.TEXT)
            {
                text.color = motocolor;
            };
        }
    }

    public void Kill()
    {
        motocolor.a = 0;
        if (thisObjType == ObjType.IMAGE)
        {
            image.color = motocolor;
        }
        else if (thisObjType == ObjType.TEXT)
        {
            text.color = motocolor;
        };
    }
}
