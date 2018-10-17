using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    //0,1,2,3の順で前、後ろ、左、右で対応
    int lastDirection = 1;
    int prevDirection = 1;
    Rigidbody2D rb2D;
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
    public enum STEP
    {
        NONE = -1,
        STOP = 0,
        MOVE,
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
                SetTargetPosition();
        
        if (step == STEP.MOVE)
            StartCoroutine("Move");
    }

    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {
        if (Input.GetKey(KeyCode.UpArrow) && button_h == false)
        {
            lastDirection = 0;
            target += new Vector3(0, 1f, 0);
            button_h = true;

        }
        if (Input.GetKey(KeyCode.DownArrow) && button_h == false)
        {
            lastDirection = 1;
            target += new Vector3(0, -1f, 0);
            button_h = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && button_h == false)
        {
            lastDirection = 2;
            target += new Vector3(-1f, 0, 0);
            button_h = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && button_h == false)
        {
            lastDirection = 3;
            target += new Vector3(1f, 0, 0);
            button_h = true;

        }
        if (lastDirection != prevDirection)
        {
            ChangeChip(direction[lastDirection], "Direction");
            ChangeChip(walk[lastDirection], "Walk");
            prevDirection = lastDirection;
        }
        if (target != prevPos)
        {
            animator.SetBool("Walk", true);
            step = STEP.MOVE;
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        button_h = false;
    }

    void ChangeChip(AnimationClip d, string name)
    {
        overrideController[name] = d;
        animator.runtimeAnimatorController = overrideController;
    }

    // ③ 目的地へ移動する
    IEnumerator Move()
    {
        float sqrRemainingDistance = (transform.position - target).sqrMagnitude;

        
        while (sqrRemainingDistance > float.Epsilon)
        {
            
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, target, 5f * Time.deltaTime);

            
            rb2D.MovePosition(newPostion);

            
            sqrRemainingDistance = (transform.position - target).sqrMagnitude;

            
            yield return null;
        }
        step = STEP.STOP;
        prevPos = transform.position;
       

    }

    

}
