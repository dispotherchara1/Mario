using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TianjinMeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("天津飯");
            Destroy(gameObject);
        }
    }
    /*
    PlayerController
    void SetTenshinhan()
    {

    }
	// Use this for initialization
	void Start () 
    {		
	}
	
	// Update is called once per frame
	void Update () 
    {		
	}*/
}
