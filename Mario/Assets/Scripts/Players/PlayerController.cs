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
    //変数定義
    //bool jump = true;
    bool invincible = false;//無敵
    public float jumpPower = 300.0f;
    public float speed = 5.0f;
    float direction = 0.0f;
    float invincibleTime = 0.0f;//無敵状態
    int x = 0; 

    enum AttackType//攻撃パターン(まだ使ってません)
    {
        PANCHI, SYORYUKEN, HADOKEN
    };
    AttackType attacktype;
    
    public bool GetInvincible()
    {
        return invincible;
    }

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        state.SetNormal();
        renderComponent = GetComponent<Renderer>();
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
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1.0f;
        }
        else
        {
            direction = 0.0f;
        }
                
        //キャラのy軸のdirection方向にspeedの力をかける
        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

        //ジャンプ判定
        if (Input.GetKeyDown(KeyCode.X))//jump)
        {
            if (x >= 1)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                x--;
                //jump = true;
            }
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
    
    void OnTriggerEnter2D(Collision2D other)
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

    void OnTriggerEnter2D(Collider2D damage)
    {
        if (damage.gameObject.CompareTag("Enemy"))
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
    }

}