using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour {
    public float a;
	// Use this for initialization
	void Start () {
        a = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        Transform mytransform = this.transform;

        Vector3 pos = mytransform.position;
        pos.x += a;

        mytransform.position = pos;
	}
}
