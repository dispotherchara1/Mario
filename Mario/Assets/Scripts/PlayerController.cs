using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 pos = new Vector2(0.0f, 0.0f);
    int x = 3;//xの移動量
    int y = 10;//yの移動量(ジャンプ)

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= x * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += x * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            pos.y += y * Time.deltaTime; 
        }
        transform.position = pos;
	}
}
