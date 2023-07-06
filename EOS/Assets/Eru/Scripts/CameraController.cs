using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float distance = -6f; // �v���C���[����̋���
    public float height = 3f; // �v���C���[����̍���

    private Vector3 offset; // �J�����̃I�t�Z�b�g

    void Start()
    {
        // �J�����̏����ʒu��ݒ�
        offset = new Vector3(0f, height, -distance);
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    void LateUpdate()
    {
        // �v���C���[�̉�]�ɍ��킹�ăJ�������ړ��E��]������
        Quaternion playerRotation = player.rotation;
        Quaternion cameraRotation = Quaternion.Euler(0f, playerRotation.eulerAngles.y, 0f);
        Vector3 desiredPosition = player.position + (cameraRotation * offset);

        transform.position = desiredPosition;
        transform.LookAt(player.position);
    }
}