using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOpuna : MonoBehaviour {

    int Bopu = 0;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
