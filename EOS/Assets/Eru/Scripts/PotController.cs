using UnityEngine;

public class PotController : MonoBehaviour
{
    public float moveSpeed = 5f;     // 移動速度
    public float jumpForce = 5f;     // ジャンプ力
    public float rotationSpeed = 100f;   // 回転速度

    private bool isJumping = false;  // ジャンプ中かどうかのフラグ

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 入力の受け取り
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 移動処理
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // 回転処理
        float rotate = (moveX != 0f || moveZ != 0f) ? Mathf.Atan2(moveX, moveZ) * Mathf.Rad2Deg : 0f;
        Quaternion targetRotation = Quaternion.Euler(0f, rotate, 0f);
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

        // ジャンプ処理
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面に接触したらジャンプフラグをリセット
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}