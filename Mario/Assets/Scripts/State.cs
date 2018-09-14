using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class State : MonoBehaviour//今は使っていません
{
    enum StateType
    {
        NORMAL, TENSHINHAN, RAMEN
    };
    StateType stateType;

    public int GetStateint()//intに変換してreturnで返しています
    {
        return (int)stateType;
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
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    //未定(モーション)           
                    Debug.Log("パンチ");
                }
                break;

            case StateType.TENSHINHAN:
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//昇竜拳
                    {
                        //未定(モーション)
                        Debug.Log("昇竜拳");
                    }
                    else
                    {
                        //未定(モーション)
                        Debug.Log("パンチ");
                    }
                }
                break;

            case StateType.RAMEN:
                if (Input.GetKeyDown(KeyCode.Z))//パンチ
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//昇竜拳
                    {
                        //未定(モーション)
                        Debug.Log("昇竜拳");
                    }
                    else
                    {
                        //未定(モーション)
                        Debug.Log("パンチ");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))//波動拳
                {
                    //未定(モーション)
                    Debug.Log("波動拳");
                }
                break;
        }
    }    


    public void GetDamage()
    {
        if (stateType > 0)
        {
            stateType--;
            Debug.Log("ダメージを受けました" + stateType);
        }
        else
        {
            //ゲームオーバー
            Debug.Log("ゲームオーバー");
        }
    }
}