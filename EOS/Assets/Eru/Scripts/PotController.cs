using UnityEngine;

public class PotController : MonoBehaviour
{
    public float moveSpeed = 5f;     // �ړ����x
    public float jumpForce = 5f;     // �W�����v��
    public float rotationSpeed = 100f;   // ��]���x

    private bool isJumping = false;  // �W�����v�����ǂ����̃t���O

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ���͂̎󂯎��
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �ړ�����
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // ��]����
        float rotate = (moveX != 0f || moveZ != 0f) ? Mathf.Atan2(moveX, moveZ) * Mathf.Rad2Deg : 0f;
        Quaternion targetRotation = Quaternion.Euler(0f, rotate, 0f);
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

        // �W�����v����
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂɐڐG������W�����v�t���O�����Z�b�g
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}