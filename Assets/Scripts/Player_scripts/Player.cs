using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Player : MonoBehaviour {
    //0,1,2,3の順で前、後ろ、左、右で対応
    int lastDirection = 1;
    int prevDirection = 1;
    int[,] walk_direction = { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 }, { 0, 0 }};
    Rigidbody2D rb2D;
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
    public enum STEP
    {
        NONE = -1,
        STOP = 0,
        MOVE = 1,
        WAIT = 2,
    };
    public STEP step = STEP.STOP;

   //animation用変数
    public AnimationClip[] direction = new AnimationClip[4];       //Direciton切り替え用
    public AnimationClip[] walk = new AnimationClip[4];             //walk切り替え用
    Animator animator;
    private AnimatorOverrideController overrideController;
    AnimatorStateInfo stateInfo;
    bool button_h = false;
    bool flagSerch = false;
    [SerializeField] GameObject moveButton;
    int waitTime = 0;
    

    void Start()
    {
        target = transform.position;
        prevPos = target;
        animator = GetComponent<Animator>();
        overrideController = new AnimatorOverrideController
        {
            runtimeAnimatorController = animator.runtimeAnimatorController
        };
        animator.runtimeAnimatorController = overrideController;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (step == STEP.MOVE)
        {
            StartCoroutine("Move");
        }
        if (step == STEP.NONE)
        {
            moveStart(0.2f);
            step = STEP.WAIT;
        }
        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            return;
        }
        touchDirection();
        if (step == STEP.STOP)
        {
            SetTargetPosition();
        }
                
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && step == STEP.STOP && flagSerch == true)
        {
            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            onClick();
        }
        

    }

    public static float MultipleRound(float value, float multiple)
    {
        return MultipleFloor(value + multiple * 0.5f, multiple);
    }

    /// <summary>
    /// より小さい倍数を求める（倍数で切り捨てられるような値）
    ///（例）倍数 = 10 のとき、12 → 10, 17 → 10
    /// </summary>
    /// <param name="value">入力値</param>
    /// <param name="multiple">倍数</param>
    /// <returns>倍数で切り捨てた値</returns>
    public static float MultipleFloor(float value, float multiple)
    {
        return Mathf.Floor(value / multiple) * multiple;
    }

    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {
        prevPos = new Vector3(
                    MultipleRound(gameObject.transform.position.x, 1),
                    MultipleRound(gameObject.transform.position.y, 1) - 1 / 2,
                    MultipleRound(gameObject.transform.position.z, 1));
        //lastDirection = 4;
        if (Input.GetKey(KeyCode.UpArrow) && button_h == false)
        {
            lastDirection = 0;
            button_h = true;

        }
        if (Input.GetKey(KeyCode.DownArrow) && button_h == false)
        {
            lastDirection = 1;
            button_h = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && button_h == false)
        {
            lastDirection = 2;
            button_h = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && button_h == false)
        {
            lastDirection = 3;
            button_h = true;

        }
        target += new Vector3(walk_direction[lastDirection, 0], walk_direction[lastDirection, 1]);
        if (lastDirection != prevDirection && lastDirection != 4)
        {
            ChangeChip(direction[lastDirection], "Direction");
            ChangeChip(walk[lastDirection], "Walk");
            prevDirection = lastDirection;
        }
        if (target != prevPos)
        {
            animator.SetTrigger("Walk");
            step = STEP.MOVE;
        }        
    }

    void ChangeChip(AnimationClip d, string name)
    {
        overrideController[name] = d;
        animator.runtimeAnimatorController = overrideController;
    }

    // ③ 目的地へ移動する
    IEnumerator Move()
    {
        float sqrRemainingDistance = 0;
        if(sqrRemainingDistance == 0)
            sqrRemainingDistance = (transform.position - target).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, target, 5f * Time.deltaTime);
            
            rb2D.MovePosition(newPostion);
            
            sqrRemainingDistance = (transform.position - target).sqrMagnitude;

            yield return null;
        }
        step = STEP.NONE;
        transform.position = new Vector3(
            MultipleRound(gameObject.transform.position.x, 1),
            MultipleRound(gameObject.transform.position.y, 1) - 1 / 2,
            MultipleRound(gameObject.transform.position.z, 1));
    }

    public void moveStart(float wait)
    {
        Invoke("waitEnd", wait);
    }
    private void waitEnd()
    {
        if (step == STEP.WAIT)
        {
            step = STEP.STOP;
            button_h = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        target = prevPos;
        transform.position = prevPos;
        
    }
    
    public void onClick()
    {
        Vector3 nowPosition = new Vector3Int(Mathf.CeilToInt(transform.position.x + walk_direction[prevDirection, 0]), Mathf.CeilToInt(transform.position.y + walk_direction[prevDirection, 1]), 0);
        try
        {
            if (GameObject.Find("GameManager").GetComponent<Item_List>().getItem(nowPosition) != null)
            {
                GameObject.Find("GameManager").GetComponent<Item_List>().getItem(nowPosition).information();
                step = STEP.WAIT;
            }
        }
        catch
        {
            Debug.Log("error");
        }
        
        
    }
    void touchDirection()
    {
        lastDirection = 4;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    flagSerch = true;
                    break;

                case TouchPhase.Stationary:
                    waitTime++;
                    if (waitTime > 20 && flagSerch == true)
                    {
                        moveButton.transform.position = t.rawPosition;
                        moveButton.SetActive(true);
                        flagSerch = false;
                    }
                    if (flagSerch == false)
                    {
                        MoveDirection(t.rawPosition, t.position);
                    }
                    break;

                case TouchPhase.Moved:
                    if (flagSerch == false)
                    {
                        MoveDirection(t.rawPosition, t.position);
                    }
                    break;

                case TouchPhase.Canceled:
                    waitTime = 0;
                    moveButton.SetActive(false);
                    break;
                case TouchPhase.Ended:
                    waitTime = 0;
                    moveButton.SetActive(false);
                    break;
            }
        }
        else
        {
            waitTime = 0;
            moveButton.SetActive(false);
        }
    }
    void MoveDirection(Vector3 prev, Vector3 next)
    {
        Vector3 movePosition = next - prev;
        if (movePosition.y > 0 && movePosition.x >= -movePosition.y && movePosition.x <= movePosition.y)
        {
            lastDirection = 0;
        }
        if (movePosition.y < 0 && movePosition.x <= -movePosition.y && movePosition.x >= movePosition.y)
        {
            lastDirection = 1;
        }
        if (movePosition.x < 0 && movePosition.y < -movePosition.x && movePosition.y > movePosition.x)
        {
            lastDirection = 2;
        }
        if (movePosition.x > 0 && movePosition.y > -movePosition.x && movePosition.y < movePosition.x)
        {
            lastDirection = 3;
        }
    }
}