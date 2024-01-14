using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTaggedObject : MonoBehaviour
{
    public string tagToFollow = "TargetTag"; // 追跡するタグ
    public float offsetY = 1.0f; // Y座標のオフセット（下に移動する距離）

    private GameObject targetObject; // 追跡するオブジェクト

    void Start()
    {
        // タグに基づいてオブジェクトを探す
        targetObject = GameObject.FindGameObjectWithTag(tagToFollow);
    }

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
        if (other.gameObject.CompareTag("Ground"))
        {
            TomatoController.isJumping = false;
        }
    }
}
