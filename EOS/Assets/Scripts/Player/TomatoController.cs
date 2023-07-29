using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float dashSpeed = 1.5f;
    public float jumpPower = 3;
    public float rollForce = 10f;
    public float deceleration = 3;

    [HideInInspector]
    public PlayerChange pc;

    [SerializeField]
    private InputActionReference jump;
    
    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private InputActionReference dash;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
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
        //cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;
        jump.action.Enable();
        move.action.Enable();
        dash.action.Enable();
    }

    void Update()
    {
        if (Stop.stopFlg)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        else rb.constraints = RigidbodyConstraints.None;

        //移動
        Vector2 moveInput = move.action.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        float dashS;
        if (dash.action.inProgress) dashS = dashSpeed;
        else dashS = 1f;
        moveDirection = moveDirection.normalized * moveSpeed * dashS;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        //ジャンプ
        if (jump.action.triggered && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Elevator"))
        {
            isJumping = false;
            jumpFlg = false;
            jumpTimeCount = 0f;
        }
        if (collision.gameObject.CompareTag("Elevator")) pc.elevatorFlg = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elevator")) pc.elevatorFlg = false;
    }
}
