﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    private GameObject _pearent;
	// Use this for initialization
	void Start () {
        _pearent = transform.root.gameObject;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(_pearent);
        }
    }
}
