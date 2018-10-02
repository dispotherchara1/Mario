using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCrear : MonoBehaviour {

    public Image Clear,Over;
    bool Gameclear = false;
    public GameOver gameover;
    public Canvas restart;

	// Use this for initialization
	void Start () {
        Clear.enabled = false;
        Over.enabled = false;
        restart.enabled = false;
	}

    // Update is called 1/f
    /// <summary>
    /// ゲームオーバーした時
    /// 画面に文字(画像)を出す
    /// </summary>
    void Update () {
        if (gameover.GetGameOver() == true)
        {
            Over.enabled = true;
            restart.enabled = true;
        }
	}

    /// <summary>
    /// こちらはクリア時
    /// 同じく画像の表示
    /// </summary>
    /// <param name="gole"></param>
    void OnTriggerEnter2D(Collider2D gole)
    {
        if (gole.gameObject.tag == "Player")
        {
            Clear.enabled = true;
            Gameclear = true;
            restart.enabled = true;
        }
    }
    /// <summary>
    /// クリアしたことを教える
    /// </summary>
    /// <returns></returns>
    public bool reClear()
    {
        return Gameclear;
    }
}
