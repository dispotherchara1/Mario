using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDown : MonoBehaviour {
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
            if (PlayerDamage >= 0)
            {
                PlayerDamage--;
            }
            else { gameover = true; }
        }

        if (col.gameObject.CompareTag("die"))
        {
            Debug.Log("即死です。");
        }

    }
    
    /// <summary>
    /// GameOverがOnに
    /// </summary>
    public void OnOver()
    {
        gameover = true;
    }
    /// <summary>
    /// GameOverがOffに
    /// </summary>
    public void OffOver()
    {
        gameover = false;

    }
    /// <summary>
    /// gameoverを渡す
    /// </summary>
    /// <returns></returns>
    public bool ReOver()
    {
        return gameover;
    }

    /// <summary>
    /// Playerが強くなるよ
    /// </summary>
    public void powup()
    {
        if (PlayerDamage <= 1)
        {
            PlayerDamage++;
        }
    }
    /// <summary>
    /// プレイヤの状況を教える
    /// </summary>
    /// <returns></returns>
    public int damage()
    {
        return PlayerDamage;
    }
}
