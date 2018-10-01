using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrock : MonoBehaviour
{
    public State state;
    GameObject ramen;
    GameObject tenshinhan;
    bool use = false;
    Vector3 pos = new Vector2(0.0f, 3.5f);
    Vector3 myPos = new Vector2(0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {  // プレハブをスクリプトのみで取得
        ramen = (GameObject)Resources.Load("Prefab/Ra-menPre");
        tenshinhan = (GameObject)Resources.Load("Prefab/TenshinhanPre");
    }

    // Update is called once per frame
    void Update ()
    {
        myPos = GameObject.Find("China_C").transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!use)
            {
                switch (state.GetStateInt())
                {
                    case 0:
                        Instantiate(tenshinhan).transform.position = myPos + pos;
                        Debug.Log("天津飯を呼びました");
                        break;
                    case 1:
                        Instantiate(ramen).transform.position = myPos + pos; 
                        Debug.Log("ラーメンを呼びました");
                        break;
                    case 2:
                        Instantiate(ramen).transform.position = myPos + pos;
                        Debug.Log("ラーメンを呼びました");
                        break;
                }
            }
            use = true;
        }
    }
}
