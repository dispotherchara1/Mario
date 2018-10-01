using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysAttackFireAfterFire : MonoBehaviour {
    GameObject player;
    public float speed = 1.0f;
    // Use this for initialization
    void Start () {
       
        player = GameObject.Find("China_C");
    }
	
	// Update is called once per frame
	void Update () {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        Destroy(gameObject, 5f);
    }
}
