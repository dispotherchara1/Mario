using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameOver : MonoBehaviour {


    int PlayerDamage = 0;
    bool gameover = false;
    
    
    
    /// <summary>
    /// PCのダメージ処理だよ
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (PlayerDamage>=0)
            {
                PlayerDamage--;
            }
            else { gameover = true; }
        }

        if (col.gameObject.CompareTag("die"))
        {
            gameOver.SetGameOver();
            Debug.Log("即死です。");
        }

    }
    /// <summary>
    /// ジャンプしていいか考えるメソッドだよ
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            x = 1;
        }
        else { x = 0; }
    }

    //gameoverがおｎになる
    public void OnOver()
    {
        gameover = true;
    }
    //がめおヴぇｒがおｆｆになる
    public void OffOver()
    {
        gameover = false;
    }
    //gameoverを渡す
    public bool ReOver()
    {
        return gameover;
    }
}
