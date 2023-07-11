using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{

    public float speed = 0.02f;
    public float areaVal = 2;

    private Transform sTransform;
    private Vector3 spos;

    private bool moveFlag = false;

    private void Start()
    {
        sTransform = this.transform;
        spos = sTransform.position;
    }

    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 mpos = myTransform.position;

        Debug.Log(mpos.x - spos.x);
        if(mpos.x - spos.x < areaVal && moveFlag == false)
        {
            mpos.x += speed;
        }
        else
        {
            moveFlag = true;
        }

        if (mpos.x - spos.x > -1*areaVal && moveFlag == true)
        {
            mpos.x -= speed;
        }
        else
        {
            moveFlag = false;
        }

        myTransform.position = mpos;  // 座標を設定
    }
}
