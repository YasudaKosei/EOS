using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float distance = -6f; // プレイヤーからの距離
    public float height = 3f; // プレイヤーからの高さ

    private Vector3 offset; // カメラのオフセット

    void Start()
    {
        // カメラの初期位置を設定
        offset = new Vector3(0f, height, -distance);
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    void LateUpdate()
    {
        // プレイヤーの回転に合わせてカメラを移動・回転させる
        Quaternion playerRotation = player.rotation;
        Quaternion cameraRotation = Quaternion.Euler(0f, playerRotation.eulerAngles.y, 0f);
        Vector3 desiredPosition = player.position + (cameraRotation * offset);

        transform.position = desiredPosition;
        transform.LookAt(player.position);
    }
}