using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float distance = 6f; // カメラとプレイヤーの距離
    public float rotationSpeed = 0.1f; // カメラの回転速度
    public float padRotationSpeed = 1.5f; // カメラの回転速度

    [SerializeField] private int targetFps = 60;

    [SerializeField] private InputActionReference _cameraX;
    [SerializeField] private InputActionReference _cameraY;

    [SerializeField] private InputActionReference _cameraPadX;
    [SerializeField] private InputActionReference _cameraPadY;

    private Vector3 offset = new Vector3(0, 4, -6); // カメラとプレイヤーのオフセット

    void Start()
    {
        Application.targetFrameRate = targetFps;

        _cameraX.action.Enable();
        _cameraY.action.Enable();
        _cameraPadX.action.Enable();
        _cameraPadY.action.Enable();
    }

    void LateUpdate()
    {
        if (player == null) return;
        if (Stop.stopFlg) return;

        //マウス用
        float mouseX = _cameraX.action.ReadValue<float>();
        float mouseY = -_cameraY.action.ReadValue<float>();

        transform.RotateAround(player.position, Vector3.up, mouseX * rotationSpeed);
        transform.RotateAround(player.position, Vector3.right, mouseY * rotationSpeed);

        // カメラの位置を更新
        Quaternion rotation = Quaternion.Euler(mouseY * rotationSpeed, mouseX * rotationSpeed, 0f);
        offset = rotation * offset;
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        //パッド用
        mouseX = _cameraPadX.action.ReadValue<float>();
        mouseY = _cameraPadY.action.ReadValue<float>();

        transform.RotateAround(player.position, Vector3.up, mouseX * padRotationSpeed);
        transform.RotateAround(player.position, Vector3.right, mouseY * padRotationSpeed);

        rotation = Quaternion.Euler(mouseY * padRotationSpeed, mouseX * padRotationSpeed, 0f);
        offset = rotation * offset;
        desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        transform.LookAt(player.position);
    }
}