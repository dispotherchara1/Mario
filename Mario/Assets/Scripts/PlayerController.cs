using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour //こっちは物理演算
{
    public Blinker blinker;
    public State state;
    public GameOver gameOver;
    Rigidbody2D rb2d;
    //変数定義
    bool jump = true;
    bool invincible = false;//無敵
    bool boushi = false;
    public float jumpPower = 300.0f;
    public float speed = 5.0f;
    float direction = 0.0f;
    float invincibleTime = 0.0f;//無敵状態

    enum AttackType//攻撃パターン(まだ使ってません)
    {
        PANCHI, SYORYUKEN, HADOKEN
    };
    AttackType attacktype;    

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        state.SetNormal();
    }

    // Update is called once per frame
    void Update()
    {
        Operation();
        state.SetAttack();
        StateNow();
    }

    void Operation()
    {
        if (!gameOver.GetGameOver())
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
    }    

    void StateNow()
    {
        if (invincible)
        {
            boushi = true;
            blinker.SetBlinker();
            Debug.Log("無敵中です");
            invincibleTime += Time.deltaTime; 

            if (invincibleTime > 3.0f)
            {
                invincible = false;
                boushi = false;
                invincibleTime = 0.0f;
                blinker.SetEnabled();
                Debug.Log("無敵が終わりました");
            }
        }
    }

    public bool GetBoushi()
    {
        return boushi;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }

    void OnTriggerStay2D(Collider2D damage)
    {
        if (damage.gameObject.CompareTag("Enemy"))
        {
            if (!invincible)
            {
                if(state.GetStateInt() > 0)
                { 
                    invincible = true;
                    state.GetDamage();
                    //state.GetDamage();
                }
                else
                {
                    gameOver.SetGameOver();
                    Debug.Log("ゲームオーバー");
                }
            }
        }
    }
}
/*
enum StateType
{
    NORMAL, TENSHINHAN, RAMEN
};
StateType stateType;

void SetTenshinhan()
{
    if (stateType < StateType.TENSHINHAN)
    {
        Debug.Log("天津飯");
        stateType = StateType.TENSHINHAN;
    }
    else
    {
        Debug.Log("天津飯を食べれません");
    }
}

void SetRamen()
{
    Debug.Log("ラーメン");
    stateType = StateType.RAMEN;
}
*/

/*
// Update is called once per frame
void Start()
{
    //コンポーネント読み込み
    rb2d = GetComponent<Rigidbody2D>();
    stateType = StateType.NORMAL;
}
*/

/*
// Update is called once per frame
void Update()
{
    Operation();
    Attack();
    StateNow();
}
*/

/*
void Attack()
{
    switch (stateType)//状態を確認
    {
        case StateType.NORMAL:
            if (Input.GetKeyDown(KeyCode.Z))//パンチ
            {
                //未定(モーション)           
                Debug.Log("パンチ");
            }
            break;

        case StateType.TENSHINHAN:
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

        case StateType.RAMEN:
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
*/

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
