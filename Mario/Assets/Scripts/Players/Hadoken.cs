using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadoken : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    bool forward = false;

    void Start()
    {
        player = GameObject.Find("China_C");
        playerController = player.GetComponent<PlayerController>();
        Transform playerTransform = GameObject.Find("China_C").transform;
        transform.position = playerTransform.position;
        forward = playerController.GetForward();
    }
    
    void Update()
    {
        float speed = 10.0f;
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed ;
        //time += Time.deltaTime;
        if (forward)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = - transform.right.normalized * speed;
            transform.localScale = new Vector3(-3, 3, 1);
        }
        Destroy(gameObject, 0.75f);
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("物に当たりました");
        }
        else
        {
            Debug.Log("アイテムに当たりました");
        }
    }
}
