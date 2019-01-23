using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //0,1,2,3の順で前、後ろ、左、右で対応
    int lastDirection = 1;
    int prevDirection = 4;
    int[,] walk_direction = { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 }, { 0, 0 } };
    Rigidbody2D rb2D;
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保

    //animation用変数
    public AnimationClip[] direction = new AnimationClip[4];       //Direciton切り替え用
    public AnimationClip[] walk = new AnimationClip[4];             //walk切り替え用
    Animator animator;
    private AnimatorOverrideController overrideController;
    AnimatorStateInfo stateInfo;
    bool button_h = false;
    bool flagSerch = true;
    [SerializeField] GameObject moveButton;
    int waitTime = 0;

    Vector3 startPos, nextPos;
    bool moveFlg = false;
    bool returnMove = false;


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


    private void Update()
    {
        if (!moveFlg)
        {
            if (Input.GetKey(KeyCode.UpArrow) || lastDirection == 0)
            {
                startPos = new Vector3(Mathf.Floor(transform.position.x),
                    Mathf.Floor(transform.position.y),
                    Mathf.Floor(transform.position.z));
                nextPos = Vector3.up;
                // rb2D.velocity = Vector3.up * 5;
                moveFlg = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || lastDirection == 1)
            {
                startPos = new Vector3(Mathf.Floor(transform.position.x),
                   Mathf.Floor(transform.position.y),
                   Mathf.Floor(transform.position.z));
                nextPos = Vector3.down;
                //rb2D.velocity = Vector3.down * 5;
                moveFlg = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || lastDirection == 2)
            {
                startPos = new Vector3(Mathf.Floor(transform.position.x),
                   Mathf.Floor(transform.position.y),
                   Mathf.Floor(transform.position.z));
                nextPos = Vector3.left;
                //                rb2D.velocity = Vector3.left * 5;
                moveFlg = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || lastDirection == 3)
            {
                startPos = new Vector3(Mathf.Floor(transform.position.x),
                    Mathf.Floor(transform.position.y),
                    Mathf.Floor(transform.position.z));
                nextPos = Vector3.right;
                // rb2D.velocity = Vector3.right * 5;
                moveFlg = true;
            }
            if (lastDirection != prevDirection && lastDirection != 4)
            {
                ChangeChip(direction[lastDirection], "Direction");
                ChangeChip(walk[lastDirection], "Walk");
                prevDirection = lastDirection;
            }
        }
    }

    void FixedUpdate()
    {
        if (moveFlg)
        {
            animator.SetBool("Walk1", true);
            transform.position += nextPos * Time.fixedDeltaTime * 5;
            if (Vector3.Distance(transform.position, startPos + nextPos) < 0.15f)
            {
                transform.position = startPos + nextPos;
                moveFlg = false;
                lastDirection = 4;
                animator.SetBool("Walk1", false);
            }

        }
        
        touchDirection();

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonDown(0)) && flagSerch == true)
        {
            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject())
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

    /// <summary>Inp
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


    void ChangeChip(AnimationClip d, string name)
    {
        overrideController[name] = d;
        animator.runtimeAnimatorController = overrideController;
    }


    public void moveStart(float wait)
    {
        Invoke("waitEnd", wait);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (moveFlg)
        {
            transform.position = startPos;
            moveFlg = false;
            lastDirection = 4;
            animator.SetBool("Walk1", false);
        }

    }

    public void onClick()
    {
        Vector3 nowPosition = new Vector3Int(Mathf.CeilToInt(transform.position.x + walk_direction[prevDirection, 0]), Mathf.CeilToInt(transform.position.y + walk_direction[prevDirection, 1]), 0);
        try
        {
            if (GameObject.Find("GameManager").GetComponent<Item_List>().getItem(nowPosition) != null)
            {
                GameObject.Find("GameManager").GetComponent<Item_List>().getItem(nowPosition).information();
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
                    if (waitTime > 10 && flagSerch == true)
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