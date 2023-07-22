using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoController : MonoBehaviour
{
    // �ړ����x
    public float moveSpeed = 5;
    // �W�����v�̋���
    public float jumpPower = 3;
    // ���[���̋���
    public float rollForce = 10f;
    // �����x
    public float deceleration = 3;

    // �W�����v�Ɋ֘A����InputActionReference
    [SerializeField]
    private InputActionReference jump;

    // �ړ��Ɋ֘A����InputActionReference
    [SerializeField]
    private InputActionReference move;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
    // �W�����v���Ԃ̃J�E���g
    private float jumpTimeCount = 0f;
    // �W�����v�̍ő厝������
    private const float jumpTime = 0.3f;
    private Camera cam;
    private Transform cameraTransform;

    void Start()
    {
        // Rigidbody�R���|�[�l���g�̎擾
        rb = GetComponent<Rigidbody>();

        // ���C���J�����̎擾
        cam = Camera.main;
        // �J������Transform�R���|�[�l���g�̎擾
        cameraTransform = cam.transform;

        // �J�����R���g���[���Ƀv���C���[�̈ʒu�ƃI�t�Z�b�g��ݒ�
        cam.GetComponent<CameraController>().player = this.transform;
        cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;

        // �W�����v�ƈړ���InputAction��L����
        jump.action.Enable();
        move.action.Enable();
    }

    void Update()
    {
        // �ړ�
        Vector2 moveInput = move.action.ReadValue<Vector2>();
        // �J�����̕������l�����Ĉړ�������ݒ�
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        // �ړ������𐳋K�����Ĉړ����x��������
        moveDirection = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // �W�����v
        if (jump.action.triggered && !isJumping)
        {
            // �W�����v�͂�������
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }

        // �W�����v���̒ǉ��̃W�����v��
        if (jump.action.ReadValue<float>() > 0 && !jumpFlg)
        {
            // �W�����v�{�^����������Ă���ԁA�W�����v���Ԃ��J�E���g
            jumpTimeCount += Time.deltaTime;
        }
        else if (isJumping)
        {
            // �W�����v�{�^���������ꂽ���ɁA�W�����v�t���O�𗧂Ă�
            jumpTimeCount = 0;
            jumpFlg = true;
        }

        if (jumpTimeCount <= jumpTime && !jumpFlg && isJumping)
        {
            // ��莞�ԓ��ł���Βǉ��̃W�����v�͂�������
            rb.AddForce(Vector3.up * jumpPower * 0.1f, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �n�ʒ��n����
        if (collision.gameObject.CompareTag("Ground"))
        {
            // �n�ʂɒ��n������W�����v�֘A�̃t���O��J�E���g�����Z�b�g
            isJumping = false;
            jumpFlg = false;
            jumpTimeCount = 0f;
        }
    }
}
