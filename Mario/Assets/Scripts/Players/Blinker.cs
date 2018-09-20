using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    float nextTime = 0.0f;
    float interval = 0.3f;  // 点滅周期
    
    // Use this for initialization
    void Start()
    {
        nextTime = Time.time;
    }
    
    public void SetBlinker(Renderer renderComponent)
    {
        if(Time.time > nextTime)
        {
            renderComponent.enabled = !renderComponent.enabled;
            nextTime += interval;
        }
    }

    public void SetEnabled(Renderer renderComponent)
    {
        nextTime = 0.0f;
        if (!renderComponent.enabled)
        {
            renderComponent.enabled = !renderComponent.enabled;
            Debug.Log(nextTime);
        }
    }
}
