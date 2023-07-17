using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float distance = 10f; // �J�����ƃv���C���[�̋���
    public float rotationSpeed = 0.1f; // �J�����̉�]���x

    [HideInInspector]
    public Vector3 offset; // �J�����ƃv���C���[�̃I�t�Z�b�g

    [SerializeField]
    private InputActionReference _camera;

    void Start()
    {
        _camera.action.Enable();
    }

    void LateUpdate()
    {
        if (player == null) return;
        if (Stop.stopFlg) return;

        if (Gamepad.current != null) rotationSpeed = 1.5f;
        else if(Joystick.current != null) rotationSpeed = 1.5f;
        else rotationSpeed = 0.1f;

        // �}�E�X��X���W�̕ω��ʂɊ�Â��ăJ��������]������
        float mouseX = _camera.action.ReadValue<float>();
        transform.RotateAround(player.position, Vector3.up, mouseX * rotationSpeed);

        // �J�����̈ʒu���X�V
        Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);
        offset = rotation * offset;
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        // �J�������v���C���[�𒆐S�Ɉړ�������
        transform.LookAt(player.position);
    }

    void OnDisable()
    {
        _camera.action.Disable();
    }
}