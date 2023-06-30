using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;     // �ǐՂ���v���C���[��Transform

    private Vector3 offset;      // �J�����ƃv���C���[�̋����I�t�Z�b�g

    void Start()
    {
        // �J�����ƃv���C���[�̏����������v�Z
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // �v���C���[�̈ʒu�ɃJ������Ǐ]������
        transform.position = target.position + offset;
    }
}