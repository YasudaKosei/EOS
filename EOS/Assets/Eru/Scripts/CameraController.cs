using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float distance = 10f; // カメラとプレイヤーの距離
    public float rotationSpeed = 1f; // カメラの回転速度

    [HideInInspector]
    public Vector3 offset; // カメラとプレイヤーのオフセット

    void LateUpdate()
    {
        if (player == null) return;

        // マウスのX座標の変化量に基づいてカメラを回転させる
        float mouseX = Input.GetAxis("Mouse X");
        transform.RotateAround(player.position, Vector3.up, mouseX * rotationSpeed);

        // カメラの位置を更新
        Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);
        offset = rotation * offset;
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        // カメラをプレイヤーを中心に移動させる
        transform.LookAt(player.position);
    }
}