using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour //こっちは物理演算
{
    //変数定義
    public float jumpPower = 300.0f;
    public float speed = 5.0f;
    float direction = 0.0f;
    float invincibleTime = 0.0f;//無敵状態
    float nextTime = 0.0f;
    float interval = 0.2f;	// 点滅周期
    Rigidbody2D rb2d;
    bool jump;
    bool invincible = false;//無敵

    enum AttackType//攻撃パターン(まだ使ってません)
    {
        panchi, syoryuken, hadoken
    };
    AttackType attacktype;

    enum StateType
    {
        normal, tenshinhan, ramen
    };
    StateType stateType;

    public void SetTenshinhan()
    {
        if (stateType != StateType.ramen)
        {
            Debug.Log("天津飯");
            stateType = StateType.tenshinhan;
        }
        else
        {
            Debug.Log("天津飯を食べれません");
        }
    }

    public void SetRamen()
    {
        Debug.Log("ラーメン");
        stateType = StateType.ramen;
    }

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        stateType = StateType.normal;
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Operation();
        Attack();
        StateNow();
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
        if (Input.GetKeyDown(KeyCode.X) && !jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            jump = true;
        }
    }

    void Attack()
    {
        switch (stateType)//状態を確認
        {
            case StateType.normal:
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    //未定(モーション)           
                    Debug.Log("パンチ");
                }
                break;

            case StateType.tenshinhan:
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//昇竜拳
                    {
                        //未定(モーション)
                        Debug.Log("昇竜拳");
                    }
                    else
                    {
                        //未定(モーション)
                        Debug.Log("パンチ");
                    }
                }
                break;

            case StateType.ramen:
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//昇竜拳
                    {
                        //未定(モーション)
                        Debug.Log("昇竜拳");
                    }
                    else
                    {
                        //未定(モーション)
                        Debug.Log("パンチ");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))//波動拳
                {
                    //未定(モーション)
                    Debug.Log("波動拳");
                }
                break;
        }
    }

    void StateNow()
    {
        var renderComponent = GetComponent<Renderer>();

        if (invincible)
        {
            Debug.Log("無敵中です");
            invincibleTime += Time.deltaTime;

            if (Time.time > nextTime)
            {
                renderComponent.enabled = !renderComponent.enabled;
                nextTime += interval;
            }

            if (invincibleTime > 3.0f)
            {
                invincible = false;
                invincibleTime = 0.0f;
                nextTime = 0.0f;

                if (!renderComponent.enabled)
                {
                    renderComponent.enabled = !renderComponent.enabled;
                }
                Debug.Log("無敵が終わりました");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }

    void OnTriggerStay2D(Collider2D damege)
    {
        if (damege.gameObject.CompareTag("Enemy"))
        {
            if (!invincible)
            {
                if (stateType > 0)
                {
                    stateType--;
                    Debug.Log("ダメージを受けました" + stateType);
                    invincible = true;
                }
                else
                {
                    //ゲームオーバー
                    Debug.Log("ゲームオーバー");
                }
            }
        }
    }
}
/*
public class PlayerController : MonoBehaviour
{
    float x = 3.0f;//xの移動量
    float y = 3.0f;//yの移動量(ジャンプ)
    Vector2 pos = new Vector2(0.0f, 0.0f);
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= x * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += x * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            pos.y += y;
        }
        this.gameObject.transform.position = pos.normalized;
    }
}*/
