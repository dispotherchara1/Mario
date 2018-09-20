using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boushi : MonoBehaviour
{
    public Blinker blinker;
    public PlayerController playerController;
    public State state;
    Renderer renderComponent;

    void Start()
    {
        renderComponent = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (state.GetBoushiLook())
        {
            if (playerController.GetInvincible())
            {
                blinker.SetBlinker_B(renderComponent);
            }
            else
            {
                blinker.SetEnabled(renderComponent);
            }
        }
        else
        {
            renderComponent.enabled = false;
        }
        Debug.Log(renderComponent.enabled + "");
	}
}
