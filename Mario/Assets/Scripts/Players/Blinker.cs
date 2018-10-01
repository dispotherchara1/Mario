using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 点滅させたいものに付ける
/// このスクリプトは使いまわせる
/// </summary>
public class Blinker : MonoBehaviour
{
    float nextTime_P = 0.0f;
    float nextTime_B = 0.0f;
    float nextTime_G = 0.0f;
    float interval = 0.3f;  // 点滅周期

    // Use this for initialization
    void Start()
    {
        nextTime_P = Time.time;
        nextTime_B = Time.time;
        nextTime_G = Time.time;
    }
    
    public void SetBlinker_P(Renderer renderComponent)
    {
        if (Time.time > nextTime_P)
        {
            renderComponent.enabled = !renderComponent.enabled;
            nextTime_P += interval;
        }
    }

    public void SetBlinker_B(Renderer renderComponent)
    {
        if (Time.time > nextTime_B)
        {
            renderComponent.enabled = !renderComponent.enabled;
            nextTime_B += interval;
        }
    }

    public void SetBlinker_G(Renderer renderComponent)
    {
        if (Time.time > nextTime_G)
        {
            renderComponent.enabled = !renderComponent.enabled;
            nextTime_G += interval;
        }
    }

    public void SetEnabled(Renderer renderComponent)
    {
        nextTime_P = 0.0f;
        nextTime_B = 0.0f;
        nextTime_G = 0.0f;

        if (!renderComponent.enabled)
        {
            renderComponent.enabled = !renderComponent.enabled;
        }
    }
}
