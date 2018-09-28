using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysAttackFireAfterFire : MonoBehaviour {
    public float AttackSpeed = 0.5f;
    GameObject player;
    bool forward = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("China_C");
        //playerController = player.GetComponent<PlayerController>();
        //Transform playerTransform = GameObject.Find("China_C").transform;
        //transform.position = playerTransform.position;
        //forward = playerController.GetForward();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
