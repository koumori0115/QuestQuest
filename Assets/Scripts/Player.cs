using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    //0,1,2,3の順で前、後ろ、左、右で対応
    int lastDirection = 1;
    int prevDirection = 4;
    int[,] walk_direction = { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 }, { 0, 0 }};
    Rigidbody2D rb2D;
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
    public enum STEP
    {
        NONE = -1,
        STOP = 0,
        MOVE = 1,
        ATTACK,
    };
    public STEP step = STEP.STOP;

   //animation用変数
    public AnimationClip[] direction = new AnimationClip[4];       //Direciton切り替え用
    public AnimationClip[] walk = new AnimationClip[4];             //walk切り替え用
    Animator animator;
    private AnimatorOverrideController overrideController;
    AnimatorStateInfo stateInfo;
    bool button_h = false;
    

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
        if (step == STEP.STOP)
        {
            SetTargetPosition();
        }

        if (step == STEP.MOVE)
        {
            StartCoroutine("Move");
        }
        if(step == STEP.NONE)
        {
            Invoke("movestart", 0.3f);
            step = STEP.ATTACK;
        }
        if (Input.GetMouseButton(0))
        {
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
        lastDirection = 4;
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

    void movestart()
    {
        if (step == STEP.ATTACK)
        {
            step = STEP.STOP;
            button_h = false;
            
            Debug.Log("bbbb");
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        target = prevPos;
        transform.position = prevPos;
        
    }
    
    public void onClick()
    {
        GetComponent<Serch>().serch(new Vector3Int((int)transform.position.x + walk_direction[lastDirection, 0], (int)transform.position.y + walk_direction[lastDirection, 1],0));
    }
}