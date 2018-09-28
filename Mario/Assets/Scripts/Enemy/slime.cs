using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    //Transform mytransform;
    public float a;
    int go =0;
    private float speed = 0.05f; //移動スピード
    private int dir = 1;        //向き（正のとき右）

    // Use this for initialization
    void Start()
    {
        a = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (go >= 1)
        {
            Transform mytransform = this.transform;

            Vector3 pos = mytransform.position;
            pos.x -= a;

            mytransform.position = pos;

            //transform.Translate(Vector3.left * speed * dir * Time.deltaTime);

            //Debug.Log("動いてるよ！");
        }
        //Debug.Log(go);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "SearchEnemy") {
            go+=1;
        }
    }

    //void OnColliderEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.name != "Player")
    //    {
    //        a = a * -1;
    //    }
    //}
    //public void Turn() {
    //    //dir = dir * -1;
    //    a = a * -1;
    //}
}