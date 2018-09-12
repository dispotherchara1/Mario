using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TianjinMeal : MonoBehaviour
{
    //State state;
    public PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //state.SetTenshinhan();//天津飯
            playerController.SetTenshinhan();//天津飯
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
