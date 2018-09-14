using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    float nextTime = 0.0f;
    float interval = 0.2f;  // 点滅周期

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time;
    } 

    public void SetBlinker()
    {
        if (Time.time > nextTime)
        {
            var renderComponent = GetComponent<Renderer>();
            renderComponent.enabled = !renderComponent.enabled;
            nextTime += interval;
        }
    }

    public void SetEnabled()
    {
        var renderComponent = GetComponent<Renderer>();
        nextTime = 0.0f;

        if (!renderComponent.enabled)
        {
            renderComponent.enabled = !renderComponent.enabled;
        }
    }
}
