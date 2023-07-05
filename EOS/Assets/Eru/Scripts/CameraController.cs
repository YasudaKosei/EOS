using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // 追従する対象（プレイヤー）

    public float rotationSpeed = 5f;  // カメラの回転速度

    private Vector3 offset;  // カメラとプレイヤーの位置オフセット

    private void Start()
    {
        offset = transform.position - target.position;  // 初期オフセットを計算
    }

    private void LateUpdate()
    {
        // プレイヤーの位置に合わせてカメラの位置を更新
        transform.position = target.position + offset;

        // カメラがプレイヤーを見るように向きを設定
        transform.LookAt(target);

        // キー入力に応じてカメラを回転させる
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            RotateCameraAroundPlayer(horizontalInput);
        }
    }

    private void RotateCameraAroundPlayer(float direction)
    {
        // カメラをプレイヤーを中心に回転させる
        transform.RotateAround(target.position, Vector3.up, direction * rotationSpeed);
    }
}