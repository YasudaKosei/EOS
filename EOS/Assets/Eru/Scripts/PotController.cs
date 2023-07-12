using UnityEngine;

public class PotController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpPower = 3;
    public float rollForce = 10f;
    public float deceleration = 3;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
    private float jumpSpeed = 1f;
    private float jumpTimeCount = 0f;
    private const float jumpTime = 0.3f;
    private Camera cam;
    private Transform cameraTransform;
    private PlayerInput playerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cameraTransform = cam.transform;
        cam.GetComponent<CameraController>().player = this.transform;
        cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;
        playerInput = new PlayerInput();
        playerInput.Enable();
    }

    void Update()
    {
        //�ړ�
        Vector2 moveInput = playerInput.actions.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized * moveSpeed * jumpSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        //�W�����v
        if (playerInput.actions.Jump.triggered && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
            jumpSpeed = 0.5f;
        }
        if (playerInput.actions.Jump.ReadValue<float>() > 0 && !jumpFlg)
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

        //��]
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rollForce * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //�n�ʒ��n����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpFlg = false;
            jumpSpeed = 1f;
            jumpTimeCount = 0f;
        }
    }
}
