﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriedRice : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("チャーハン");
            Destroy(gameObject);
        }
    }
    /*
	// Use this for initialization
	void Start () 
    {		
	}
	
	// Update is called once per frame
	void Update () 
    {		
	}*/
}
