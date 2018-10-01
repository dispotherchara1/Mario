using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOpuna : MonoBehaviour {

    int Bopu = 0;
    public Collider2D Wall;

    // Use this for initialization
	void Start () {
        Wall.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Bopu >= 1)
        {
            Wall.enabled = true;
        }
	}

    /// <summary>
    /// ボス判定にプレイヤが来ると戦闘開始だよ
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "VSBoss")
        {
            Bopu++;
        }
    }

    
}
