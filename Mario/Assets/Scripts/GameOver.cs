using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver = false;

    public bool GetGameOver()
    {
        return gameOver;
    }

    public void SetGameOver()
    {
        gameOver = true;
    }
}
