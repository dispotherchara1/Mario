using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class State : MonoBehaviour
{
    GameObject hadoken;
    public PlayerController playerController;
    bool boushiLook = false;
    bool gloveLook = false;
    float time = 0.0f;
    float timeInterval = 1.0f;
    //PlayerController Plecon;
    //int LorR = 1;//右か左かをhadokenに教える

    void Start()
    {   // プレハブをスクリプトのみで取得
        hadoken = (GameObject)Resources.Load("Prefab/hadokenPre");
    }

    enum StateType
    {
        NORMAL, TENSHINHAN, RAMEN
    };

    StateType stateType;

    public bool GetBoushiLook()
    {
        return boushiLook;
    }

    public bool GetGloveLook()
    {
        return gloveLook;
    }
    
    public int GetStateInt()//intに変換してreturnで返しています
    {
        return (int)stateType;
    }

    public void GetDamage()
    {
        stateType--;
        Debug.Log("ダメージを受けました" + stateType);
    }

    public void SetNormal()
    {
        stateType = StateType.NORMAL;
    }

    public void SetTenshinhan()
    {
        if (stateType < StateType.TENSHINHAN)
        {
            Debug.Log("天津飯");
            stateType = StateType.TENSHINHAN;
        }
        else
        {
            Debug.Log("天津飯を食べれません");
        }
    }

    public void SetRamen()
    {
        Debug.Log("ラーメン");
        stateType = StateType.RAMEN;
    }
    
    public void SetAttack()
    {
        switch (stateType)//状態を確認
        {
            case StateType.NORMAL:
                boushiLook = false;
                gloveLook = false;
                //this.transform.localScale = new Vector3(1, 1, 1);
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    //モーション
                    playerController.SetAnimator1();
                    Debug.Log("パンチ");
                }
                break;

            case StateType.TENSHINHAN:
                boushiLook = true;
                gloveLook = false;
                //this.transform.localScale = new Vector3(2, 2, 1);
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//昇竜拳
                    {
                        //モーション
                        playerController.SetAnimator2();
                        Debug.Log("昇竜拳");
                    }
                    else
                    {
                        //モーション
                        playerController.SetAnimator1();
                        Debug.Log("パンチ");
                    }
                }
                break;

            case StateType.RAMEN:
                boushiLook = true;
                gloveLook = true;
                //this.transform.localScale = new Vector3(2, 2, 1);
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//昇竜拳
                    {
                        //モーション
                        playerController.SetAnimator2();
                        Debug.Log("昇竜拳");
                    }
                    else
                    {
                        //モーション
                        playerController.SetAnimator1();
                        Debug.Log("パンチ");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))//波動拳
                {     
                    if(timeInterval < time)
                    {
                        //モーション
                        playerController.SetAnimator1();
                        Instantiate(hadoken);
                        time = 0.0f;
                        Debug.Log("波動拳");
                    }
                    else
                    {
                        Debug.Log("クールタイム");
                    }
                }
                time += Time.deltaTime;
                break;
        }
    }    

    /*
    public void GetDamage()
    {
        if (stateType > 0)
        {
            stateType--;
            Debug.Log("ダメージを受けました" + stateType);
        }
        else
        {
            gameOver.SetGameOver();
            Debug.Log("ゲームオーバー");
        }
    }*/
}