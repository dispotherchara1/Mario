using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TianjinMeal : MonoBehaviour
{
    GameObject player;
    State state;

    void Start()
    {
        player = GameObject.Find("China_C");
        state = player.GetComponent<State>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            state.SetTenshinhan();//天津飯
            //playerController.SetTenshinhan();//天津飯
            Destroy(gameObject);
        }
    }
}
