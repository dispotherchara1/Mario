using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    Rigidbody2D rb2d;
    Renderer renderComponent;
    Animator animator;
    float direction = 0.0f;
    public float speed = 5.0f;
    bool forward = true;            //向きの確保
    public int x = 0;               //xが１以上の時ジャンプを可能にする
    public float jumpPower = 580.0f;//ジャンプする高さ

    void Start()
    {
        //state.SetNormal();
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        renderComponent = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        /*
         *https://twitter.com/developh_priv/status/1044871690893840384
        */
    }

    /// <summary>
    /// キーボード操作
    /// </summary>
    void Operation()
    {
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

        if (direction != 0)
        {
            transform.localScale = new Vector3(direction * 2, 2, 2);
        }

        //ジャンプ判定
        //数値が１以上持っていない場合はジャンプできない
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (x >= 1)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
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

    /// <summary>
    /// ジャンプしていいか考えるメソッドだよ
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay2D(Collider2D other)
    {
        //地面と接触している場合xを１にする。
        if (other.gameObject.CompareTag("Ground"))
        {
            x = 1;
        }
        else { x = 0; }
    }
}
