using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramen : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("ラーメン");
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
