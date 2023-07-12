using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float distance = 10f; // �J�����ƃv���C���[�̋���
    public float rotationSpeed = 0.1f; // �J�����̉�]���x

    [HideInInspector]
    public Vector3 offset; // �J�����ƃv���C���[�̃I�t�Z�b�g

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();
    }

    void LateUpdate()
    {
        if (player == null) return;

        // �}�E�X��X���W�̕ω��ʂɊ�Â��ăJ��������]������
        float mouseX = playerInput.actions.Camera.ReadValue<float>();
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
        playerInput.Disable();
    }
}