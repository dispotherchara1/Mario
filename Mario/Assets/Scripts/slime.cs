using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float a;
    //Transform mytransform;
    int go =0;
    // Use this for initialization
    void Start()
    {
        a = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (go >= 1)
        {        Transform mytransform = this.transform;

            Vector3 pos = mytransform.position;
            pos.x -= a;

            mytransform.position = pos;
        }
        //Debug.Log(go);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "SearchEnemy") {
            go+=1;
        }
    }
}