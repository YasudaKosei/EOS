using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float distance = 6f; // �J�����ƃv���C���[�̋���
    public float rotationSpeed = 0.1f; // �J�����̉�]���x
    public float padRotationSpeed = 1.5f; // �J�����̉�]���x

    [SerializeField]
    private int targetFps = 60;

    //[HideInInspector]
    public Vector3 offset = new Vector3(0,4,-6); // �J�����ƃv���C���[�̃I�t�Z�b�g

    [SerializeField]
    private InputActionReference _camera;

    [SerializeField]
    private InputActionReference _padCamera;

    void Start()
    {
        Application.targetFrameRate = targetFps;

        //�L����
        _camera.action.Enable();
        _padCamera.action.Enable();
    }

    void LateUpdate()
    {
        if (player == null) return;
        if (Stop.stopFlg) return;

        //�}�E�X�p
        // �}�E�X��X���W�̕ω��ʂɊ�Â��ăJ��������]������
        float mouseX = _camera.action.ReadValue<float>();
        transform.RotateAround(player.position, Vector3.up, mouseX * rotationSpeed);

        // �J�����̈ʒu���X�V
        Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);
        offset = rotation * offset;
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        // �J�������v���C���[�𒆐S�Ɉړ�������
        //transform.LookAt(player.position);

        //�p�b�h�p
        mouseX = _padCamera.action.ReadValue<float>();
        transform.RotateAround(player.position, Vector3.up, mouseX * padRotationSpeed);

        rotation = Quaternion.Euler(0f, mouseX * padRotationSpeed, 0f);
        offset = rotation * offset;
        desiredPosition = player.position + offset;
        transform.position = desiredPosition;

        //transform.LookAt(player.position);
    }
}