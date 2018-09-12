using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motin : MonoBehaviour {
    float a;
	// Use this for initialization
	void Start () {
        a = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        Transform mytransform = this.transform;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 pos = mytransform.position;
            pos.x += a;

            mytransform.position = pos;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 pos = mytransform.position;
            pos.x -= a;

            mytransform.position = pos;
        }
    }
}
