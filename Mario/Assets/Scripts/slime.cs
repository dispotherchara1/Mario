using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class OnTriggerEnter2D : MonoBehaviour {
=======
public class slime : MonoBehaviour {
>>>>>>> origin/Honjo
    public float a;
	// Use this for initialization
	void Start () {
        a = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        Transform mytransform = this.transform;

        Vector3 pos = mytransform.position;
<<<<<<< HEAD
        pos.x -= a;

        mytransform.position = pos;
	}
    private OntriggerEnter2D(Collider2D col)
    {

    }
=======
        pos.x += a;

        mytransform.position = pos;
	}
>>>>>>> origin/Honjo
}
