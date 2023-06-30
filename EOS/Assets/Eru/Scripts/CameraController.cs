using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;     // 追跡するプレイヤーのTransform

    private Vector3 offset;      // カメラとプレイヤーの距離オフセット

    void Start()
    {
        // カメラとプレイヤーの初期距離を計算
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // プレイヤーの位置にカメラを追従させる
        transform.position = target.position + offset;
    }
}