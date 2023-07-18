using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float distance = 10f; // カメラとプレイヤーの距離
    public float rotationSpeed = 0.1f; // カメラの回転速度
    public float padRotationSpeed = 1.5f; // カメラの回転速度

    [HideInInspector]
    public Vector3 offset; // カメラとプレイヤーのオフセット

    [SerializeField]
    private InputActionReference _camera;

    [SerializeField]
    private InputActionReference _padCamera;

    void Start()
    {
        _camera.action.Enable();
        _padCamera.action.Enable();
    }

    void LateUpdate()
    {
        if (player == null) return;
        if (Stop.stopFlg) return;

        //マウス用
        // マウスのX座標の変化量に基づいてカメラを回転させる
        float mouseX = _camera.action.ReadValue<float>();
        transform.RotateAround(player.position, Vector3.up, mouseX * rotationSpeed);

        // カメラの位置を更新
        Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);
        offset = rotation * offset;
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        // カメラをプレイヤーを中心に移動させる
        transform.LookAt(player.position);

        //パッド用
        mouseX = _padCamera.action.ReadValue<float>();
        transform.RotateAround(player.position, Vector3.up, mouseX * padRotationSpeed);

        rotation = Quaternion.Euler(0f, mouseX * padRotationSpeed, 0f);
        offset = rotation * offset;
        desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        transform.LookAt(player.position);
    }

    void OnDisable()
    {
        _camera.action.Disable();
        _padCamera.action.Disable();
    }
}