using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour //こっちは物理演算
{
    //変数定義
    public float jumpPower = 300.0f;
    public float speed = 5.0f;
    float direction = 0.0f;
    Rigidbody2D rb2d;
    bool jump = false;

    enum ModeType
    {
        normal, tensinhan, ramen
    };
    ModeType modetype;

    enum AttackType//攻撃パターン
    {
        panchi, syoryuken , hadoken
    };
    AttackType attacktype;

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Operation();
        Attack();
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
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
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
