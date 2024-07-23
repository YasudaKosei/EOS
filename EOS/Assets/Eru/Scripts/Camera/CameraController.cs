using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player;         // プレイヤーのTransform
    [SerializeField]
    private float distance = 10.0f;    // プレイヤーからの距離
    [SerializeField]
    private float sensitivity = 5.0f; // マウスやスティックの感度
    [SerializeField]
    private float maxYAngle = 80f;    // カメラの縦方向の制限角度
    private Vector2 rotation = Vector2.zero; // カメラの回転を保持するための変数
    private Vector3 offset;          // プレイヤーとカメラのオフセット

    [SerializeField]
    private InputActionReference cameraXY;

    private void Start()
    {
        offset = new Vector3(0, 0, -distance);
        cameraXY.action.Enable();
    }

    private void Update()
    {
        if (Stop.stopFlg) return;

        // マウスやスティックの入力を取得
        Vector2 input = cameraXY.action.ReadValue<Vector2>();

        // 入力がある場合のみカメラを回転させる
        if (input.magnitude > 0.1f)
        {
            int x = DisplayManager.inversionX ? -1 : 1;
            int y = DisplayManager.inversionY ? 1 : -1;

            rotation.x += input.x * DisplayManager.sensitivityX * x;
            rotation.y -= input.y * DisplayManager.sensitivityY * y;
            rotation.y = Mathf.Clamp(rotation.y, -maxYAngle, maxYAngle); // 縦方向の制限
        }

        // 回転を適用
        Quaternion rotationQuat = Quaternion.Euler(rotation.y, rotation.x, 0);
        transform.position = player.position + rotationQuat * offset;
        transform.LookAt(player.position);

        // プレイヤーの移動に合わせてカメラも移動
        Vector3 desiredPosition = player.position + rotationQuat * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5.0f);
    }
}
