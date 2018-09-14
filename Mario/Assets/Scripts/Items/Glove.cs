using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour
{

    public Blinker blinker;
    public PlayerController playerController;
    public State state;
    // Update is called once per frame
    void Update()
    {
        var renderComponent = GetComponent<Renderer>();

        if (state.GetBoushiLook())
        {
            if (playerController.GetBoushi())
            {
                blinker.SetBlinker();
            }
            else
            {
                blinker.SetEnabled();
            }
        }
        else
        {
            renderComponent.enabled = false;
        }
    }
}
