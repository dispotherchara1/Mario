using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoryuken : MonoBehaviour
{
    GameObject player;
    Collider2D ShoryukenCollider2d;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("China_C");
        animator = player.GetComponent<Animator>();
        ShoryukenCollider2d = GetComponent<Collider2D>();
        ShoryukenCollider2d.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack2"))
        {
            ShoryukenCollider2d.isTrigger = true;
        }
        else
        {
            ShoryukenCollider2d.isTrigger = false;
        }
        Debug.Log("昇竜拳" + ShoryukenCollider2d.isTrigger);
    }
}
