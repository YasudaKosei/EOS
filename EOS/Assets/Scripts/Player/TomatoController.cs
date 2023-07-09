using UnityEngine;

public class TomatoController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpPower = 3;
    public float deceleration = 3;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
    private float jumpSpeed = 1f;
    private float jumpTimeCount = 0f;
    private Camera cam;
    private Transform cameraTransform;

    private const float jumpTime = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cameraTransform = cam.transform;
        cam.GetComponent<CameraController>().player = this.transform;
        cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;
    }

    void Update()
    {
        //移動
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += cameraTransform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= cameraTransform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= cameraTransform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += cameraTransform.right;
        }

        moveDirection = moveDirection.normalized * moveSpeed * jumpSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

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
