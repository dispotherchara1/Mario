using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour //こっちは物理演算
{
    public Blinker blinker;
    public State state;
    public GameOver gameOver;
    Rigidbody2D rb2d;
    Renderer renderComponent;
    Animator animator;
    //変数定義
    //bool jump = true;
    bool invincible = false;//無敵
    bool forward = true;//正面
    public float jumpPower = 300.0f;
    public float speed = 5.0f;
    float direction = 0.0f;
    float invincibleTime = 0.0f;//無敵状態
    public int x = 0; 

    enum AttackType//攻撃パターン(まだ使ってません)
    {
        PANCHI, SYORYUKEN, HADOKEN
    };
    AttackType attacktype;

    public bool GetForward()
    {
        return forward;
    }
    
    public bool GetInvincible()
    {
        return invincible;
    }
    
    public void SetAnimator1()
    {
        animator.SetTrigger("AttackTrigger1");
    }

    public void SetAnimator2()
    {
        animator.SetTrigger("AttackTrigger2");
    }

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        state.SetNormal();
        renderComponent = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver.GetGameOver())
        {
            Operation();
            state.SetAttack();
            StateNow();
        }
        else
        {
            Debug.Log("ゲームオーバー");
        }
    }

    void Operation()
    {
        //キーボード操作
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1.0f;
            forward = true;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1.0f;
            forward = false;
        }
        else
        {
            direction = 0.0f;
        }
                
        //キャラのy軸のdirection方向にspeedの力をかける
        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

        if(direction != 0)
        {
            transform.localScale = new Vector3(direction * 2, 2, 2);
        }
        
        //ジャンプ判定
        if (Input.GetKeyDown(KeyCode.X))//jump)
        {
            if (x >= 1)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                //jump = true;
            }
        }

        if (direction != 0 || animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack1") 
                           || animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack2"))
        {
            animator.speed = speed / 2;
        }
        else
        {
            animator.speed = 0;
        }
    }

    void StateNow()
    {
        if (invincible)
        {
            blinker.SetBlinker_P(renderComponent);
            Debug.Log("無敵中です");
            invincibleTime += Time.deltaTime; 

            if (invincibleTime > 3.0f)
            {
                invincible = false;
                invincibleTime = 0.0f;
                blinker.SetEnabled(renderComponent);
                Debug.Log("無敵が終わりました");
            }
        }
    }
    
/*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (x < 1)//１　or　０
            {
                x++;
            }
            //jump = false;
        }
    }
    */

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag==("Ground"))//.gameObject.CompareTag("Ground"))
    //    {
    //        if (x < 1)//１　or　０
    //        {
    //            x++;
    //        }
    //        //jump = false;
    //    }
    //    else
    //    {
    //        x = 0;
    //    }
    //}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!invincible)
            {
                if(state.GetStateInt() > 0)
                { 
                    invincible = true;
                    state.GetDamage();
                }
                else
                {
                    gameOver.SetGameOver();
                    Debug.Log("ゲームオーバーになりました");
                }
            }
        }

        if (other.gameObject.CompareTag("die"))
        {
            gameOver.SetGameOver();
            Debug.Log("即死です。");
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            x = 1;
        }
        else { x = 0; }
    }
   /* /// <summary>
    /// DirectionをHadokenに見せるためのメソッド
    /// </summary>
    /// <returns></returns>
    public float lookDirection()
    {
        return direction;
    }*/
}