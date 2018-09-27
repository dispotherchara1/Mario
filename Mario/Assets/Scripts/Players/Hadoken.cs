using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadoken : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    float time = 0.0f;
    float timeInterval = 0.5f;
    //Vector3 Set = new Vector2(1.0f, 0.0f);
    PlayerController PleCon;

    void Start()
    {
        player = GameObject.Find("China_C");
        Transform playerTransform = GameObject.Find("China_C").transform;
        transform.position = playerTransform.position;// + Set;
    }
    
    void Update()
    {
        float speed = 10.0f;
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed ;
        /*time += Time.deltaTime;
        if (time > timeInterval)
        {
            Destroy(gameObject);    // 自分自身を削除
        }*/
        Destroy(gameObject, 0.7f);
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Items"))
        {
            //Destroy(gameObject);
            Debug.Log("物に当たりました");
        }
        else
        {
            Debug.Log("アイテムに当たりました");
        }
    }
}
