﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryonCamera : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothing//+=Time.deltaTime)
        );

    }
}
