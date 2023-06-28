using UnityEngine;

public class PotController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotationSpeed = 5;
    public float jumpPower = 3;
    public float deceleration = 3;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
    private float jumpSpeed = 1f;
    private float jumpTimeCount = 0f;

    private const float jumpTime = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //移動
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Quaternion horizontalRotation = Quaternion.Euler(0f, moveHorizontal * rotationSpeed, 0f);
        Quaternion verticalRotation = Quaternion.Euler(0f, 0f, moveVertical * rotationSpeed);
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            rb.AddForce(movement * moveSpeed * jumpSpeed);
            rb.MoveRotation(rb.rotation * horizontalRotation);
            rb.MoveRotation(rb.rotation * verticalRotation);
        }

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
            jumpSpeed = 0.5f;
        }
        if (Input.GetKey(KeyCode.Space) && !jumpFlg)
        {
            jumpTimeCount += Time.deltaTime;
        }
        else if (isJumping)
        {
            jumpTimeCount = 0;
            jumpFlg = true;
        }
        if (jumpTimeCount <= jumpTime && !jumpFlg && isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower * 0.1f, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //地面着地判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpFlg = false;
            jumpSpeed = 1f;
            jumpTimeCount = 0f;
        }
    }
}
