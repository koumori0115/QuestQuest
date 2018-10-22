using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CPU : MonoBehaviour {

    Vector3 MOVEX = new Vector3(1f, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 1f, 0); // y軸方向に１マス移動するときの距離

    float step = 4f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    Animator animator;   // アニメーション

    int wait = 150;
    int moveR;

    Vector3 Initialpos;


    // Use this for initialization
    void Start()
    {
        Initialpos = transform.position;
        target = transform.position;    //自分のポジション保存
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        wait += 1;

        if(wait >= 100){

            moveR = UnityEngine.Random.Range(0, 5);
            wait = 0;

            if (transform.position == target)
            {
                SetTargetPosition();
            }

        }

        Move();

        // ① 移動中かどうかの判定。移動中でなければ入力を受付

    }

    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {

        //prevPos = target;

        //最初に指定した場所と現在の場所を引いて一定の数字以上であれば動く。
        //そうでないならもう一度乱数を生成し直す
        //もしCPUの移動範囲を広げたいならif分の数字をいじれば変わる…はず
        //乱数生成してる間にwaitの値が溜まっても困るので「wait」をここのelseでも0にする。念のため

        if (moveR == 0)
        {
            if (Initialpos.x - target.x > -4)       
            {

                target = transform.position + MOVEX;
                //SetAnimationParam(1);
                return;

            }
            else
            {
                moveR = UnityEngine.Random.Range(0, 5);
                wait = 0;
            }
        }

        if (moveR == 1)
        {
            if (Initialpos.x - target.x < 4)
            {
                target = transform.position - MOVEX;
                //SetAnimationParam(2);
                return;
            }
            else
            {
                moveR = UnityEngine.Random.Range(0, 5);
                wait = 0;
            }
        }

        if (moveR == 2)
        {
            if (Initialpos.y - target.y > -4)
            {
                target = transform.position + MOVEY;
                //SetAnimationParam(3);
                return;
            }
            else
            {
                moveR = UnityEngine.Random.Range(0, 5);
                wait = 0;
            }
         }

        if (moveR == 3)
        {
            if (Initialpos.y - target.y < 4)
            {
                target = transform.position - MOVEY;
                //SetAnimationParam(0);
                return;
            }
            else
            {
                moveR = UnityEngine.Random.Range(0, 5);
                wait = 0;
            }
        }

        if (moveR == 4)
        {
            return;
        }

    }

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
/*    void SetAnimationParam(int param)
    {
        //animator.SetInteger("WalkParam", param);
    }
*/
    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

}
