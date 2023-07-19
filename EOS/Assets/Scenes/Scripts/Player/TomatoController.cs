using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpPower = 3;
    public float rollForce = 10f;
    public float deceleration = 3;

    [SerializeField]
    private InputActionReference jump;

    [SerializeField]
    private InputActionReference move;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
    //private float jumpSpeed = 1f;
    private float jumpTimeCount = 0f;
    private const float jumpTime = 0.3f;
    private Camera cam;
    private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cameraTransform = cam.transform;
        cam.GetComponent<CameraController>().player = this.transform;
        cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;
        jump.action.Enable();
        move.action.Enable();
    }

    void Update()
    {
        //移動
        Vector2 moveInput = move.action.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        //moveDirection = moveDirection.normalized * moveSpeed * jumpSpeed;
        moveDirection = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        //ジャンプ
        if (jump.action.triggered && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
            //jumpSpeed = 0.5f;
        }
        if (jump.action.ReadValue<float>() > 0 && !jumpFlg)
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
            //jumpSpeed = 1f;
            jumpTimeCount = 0f;
        }
    }
}
