using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hadokenDeath : MonoBehaviour {
    private GameObject _pearent;//_child;
    public int HP =1;
    // Use this for initialization
    void Start()
    {
        _pearent = transform.root.gameObject;
        /*int count = 0;
        foreach (Transform child in transform)
        {
            //child is your child transform

            //Debug.Log("Child[" + count + "]:" + child.name);
            count++;
        }*/
    }

    private void Update()
    {
        if (HP<=0) {
            Destroy(gameObject);//_pearent);
        }
    }

    /// <summary>
    ///　敵のHPを減らすよ。パンチ１ダメ、波動拳２ダメ、昇竜拳３ダメ。 
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "panchi")
        {
            HP--;
        }

        if (col.tag == "hadoken")
        {
            HP -= 2;
        }

        if (col.tag == "shoryuken")
        {
            HP -= 3;
        }
    }
}
