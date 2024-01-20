using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTaggedObject : MonoBehaviour
{
    public float offsetY = 1.0f; // Y座標のオフセット（下に移動する距離）

    private GameObject targetObject; // 追跡するオブジェクト

    TomatoController tomatoController;
    BroccoliController broccoliController;
    CarrotController carrotController;
    WatermelonController watermelonController;

    [HideInInspector]
    public PC pc;

    void Update()
    {
        // ターゲットオブジェクトが存在する場合、その位置にオフセットを加えて移動する
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.transform.position;
            transform.position = new Vector3(targetPosition.x, targetPosition.y - offsetY, targetPosition.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //地面着地判定
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Elevator"))
        {
            if (tomatoController) tomatoController.isJumping = false;
            if (broccoliController) broccoliController.isJumping = false;
            if (carrotController) carrotController.isJumping = false;
            if (watermelonController) watermelonController.isJumping = false;
        }
        if (other.gameObject.CompareTag("Elevator")) pc.elevatorFlg = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Elevator")) pc.elevatorFlg = false;
    }

    public void TomatoSerect(float Y, GameObject target, Vector3 objsize)
    {
        offsetY = Y;
        this.gameObject.transform.localScale = objsize;
        targetObject = target;
        tomatoController = targetObject.GetComponent<TomatoController>();
    }
    public void BroccoliSerect(float Y, GameObject target, Vector3 objsize)
    {
        offsetY = Y;
        this.gameObject.transform.localScale = objsize;
        targetObject = target;
        broccoliController = targetObject.GetComponent<BroccoliController>();
    }
    public void CarrotSerect(float Y, GameObject target, Vector3 objsize)
    {
        offsetY = Y;
        this.gameObject.transform.localScale = objsize;
        targetObject = target;
        carrotController = targetObject.GetComponent<CarrotController>();
    }
    public void WatermelonSerect(float Y, GameObject target, Vector3 objsize)
    {
        offsetY = Y;
        this.gameObject.transform.localScale = objsize;
        targetObject = target;
        watermelonController = targetObject.GetComponent<WatermelonController>();
    }

}
