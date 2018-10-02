using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver = false;//ゲームオーバー判定スイッチ

    /// <summary>
    /// ゲームオーバーをOnにする
    /// </summary>
    /// <returns></returns>
    public bool GetGameOver()
    {
        return gameOver;
    }
    /// <summary>
    /// ゲームオーバーをOffにする
    /// </summary>
    public void SetGameOver()
    {
        gameOver = true;
    }
}
