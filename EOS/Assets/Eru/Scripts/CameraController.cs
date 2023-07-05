using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // �Ǐ]����Ώہi�v���C���[�j

    public float rotationSpeed = 5f;  // �J�����̉�]���x

    private Vector3 offset;  // �J�����ƃv���C���[�̈ʒu�I�t�Z�b�g

    private void Start()
    {
        offset = transform.position - target.position;  // �����I�t�Z�b�g���v�Z
    }

    private void LateUpdate()
    {
        // �v���C���[�̈ʒu�ɍ��킹�ăJ�����̈ʒu���X�V
        transform.position = target.position + offset;

        // �J�������v���C���[������悤�Ɍ�����ݒ�
        transform.LookAt(target);

        // �L�[���͂ɉ����ăJ��������]������
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            RotateCameraAroundPlayer(horizontalInput);
        }
    }

    private void RotateCameraAroundPlayer(float direction)
    {
        // �J�������v���C���[�𒆐S�ɉ�]������
        transform.RotateAround(target.position, Vector3.up, direction * rotationSpeed);
    }
}