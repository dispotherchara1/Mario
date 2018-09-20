using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadoken : MonoBehaviour
{
    GameObject player;
    float time = 0.0f;
    float timeInterval = 0.5f;

    void Start()
    {
        player = GameObject.Find("player");
        Transform playerTransform = GameObject.Find("Player").transform;
        transform.position = playerTransform.position;
    }
    
    void Update()
    {
        float speed = 10.0f;
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
        time += Time.deltaTime;
        if (time > timeInterval)
        {
            Destroy(gameObject);    // 自分自身を削除
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Items"))
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
