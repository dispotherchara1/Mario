using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panchi : MonoBehaviour
{
    GameObject player;
    Collider2D panchiCollider2d;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("China_C");
        animator = player.GetComponent<Animator>();
        panchiCollider2d = GetComponent<Collider2D>();
        panchiCollider2d.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack1"))
        {
            panchiCollider2d.enabled = true;
        }
        else
        {
            panchiCollider2d.enabled = false;
        }

        //Debug.Log("波動拳" + panchiCollider2d.enabled);

	}
}
