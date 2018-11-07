using UnityEngine;
using System.Collections;

public class TapObserver : MonoBehaviour
{

    private enum TAP_STATUS
    {
        NONE = -1,

        UP = 0,
        DOWN,
        TAP,
        END,
        CANCEL,
    };

    private TAP_STATUS tapStatus = TAP_STATUS.UP;
    private TAP_STATUS tapStatusNext = TAP_STATUS.NONE;

    public delegate void funcDelegate();
    public funcDelegate callbackFunction = null;

    public int x = 0;
    public int y = 0;
    public int w = 100;
    public int h = 100;

    // Update is called once per frame
    void Update()
    {

        switch (tapStatus)
        {
            case TAP_STATUS.UP:
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.fingerId == 0)
                    {
                        Rect rect = new Rect(x, y, w, h);
                        bool contain = rect.Contains(touch.position);

                        if (contain)
                        {
                            tapStatusNext = TAP_STATUS.TAP;
                        }
                        else
                        {
                            tapStatusNext = TAP_STATUS.DOWN;
                        }
                    }
                }

                break;

            case TAP_STATUS.TAP:

                if (Input.touchCount == 0 || foundFingerId() == false)
                {
                    tapStatusNext = TAP_STATUS.END;
                }
                else
                {
                    Touch touch = Input.GetTouch(0);
                    Rect rect = new Rect(x, y, w, h);
                    bool contain = rect.Contains(touch.position);

                    if (contain == false)
                    {
                        tapStatusNext = TAP_STATUS.CANCEL;
                    }
                }

                break;

            case TAP_STATUS.DOWN:
            case TAP_STATUS.CANCEL:

                if (Input.touchCount == 0 || foundFingerId() == false)
                {
                    tapStatusNext = TAP_STATUS.UP;
                }

                break;

            case TAP_STATUS.END:

                tapStatusNext = TAP_STATUS.UP;

                break;
        }

        while (tapStatusNext != TAP_STATUS.NONE)
        {
            tapStatus = tapStatusNext;
            tapStatusNext = TAP_STATUS.NONE;

            switch (tapStatus)
            {
                case TAP_STATUS.TAP:
                    callbackFunction();
                    break;

                case TAP_STATUS.DOWN:

                    break;

                case TAP_STATUS.END:

                    

                    break;

                case TAP_STATUS.CANCEL:

                    break;
            }
        }
    }

    bool foundFingerId()
    {
        bool ret = false;

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == 0) ret = true;
            }
        }

        return ret;
    }

}


