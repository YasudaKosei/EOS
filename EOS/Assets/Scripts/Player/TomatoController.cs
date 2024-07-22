using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TomatoController : MonoBehaviour, Skill
{
    public float moveSpeed = 5;
    public float downMoveSpeed = 3;
    public float jumpPower = 3;
    public float rollForce = 10f;
    public float deceleration = 3;

    public float skillTime = 5;
    public float skillUpVal = 2;

    [HideInInspector]
    public PC pc;

    [HideInInspector]
    public bool knockBackFlg = false;

    public bool isJumping = false;

    [SerializeField]
    private InputActionReference jump;

    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private float movementThreshold = 3f;

    private Rigidbody rb;
    private float lateralmoveSpeed;
    private Camera cam;
    private Transform cameraTransform;

    [SerializeField]
    private float groundOffsetY = 0.6f;

    [SerializeField]
    private LayerMask layerMask;

    private bool jumpDelayFlg = false;

    [SerializeField]
    private float jumpDelayTime = 0.1f;

    [SerializeField]
    private AudioClip audioClipJump;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        cam.GetComponent<CameraController>().player = gameObject.transform;
        cameraTransform = cam.transform;
        jump.action.Enable();
        move.action.Enable();
        isJumping = false;
        jumpDelayFlg = false;
    }

    void Update()
    {
        if (Stop.stopFlg)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        else rb.constraints = RigidbodyConstraints.None;

        if (knockBackFlg)
        {
            if (rb.velocity.magnitude < movementThreshold) knockBackFlg = false;
            return;
        }

        lateralmoveSpeed = moveSpeed;

        // 移動
        Vector2 moveInput = move.action.ReadValue<Vector2>();

        // 横移動はジャンプ時は減速
        Vector3 lateralMove = new Vector3(moveInput.x, 0, 0) * lateralmoveSpeed;

        // 前後移動はジャンプ時も常の移動速度を使用
        Vector3 forwardMove = new Vector3(0, 0, moveInput.y) * moveSpeed;

        // カメラの向きに基づいて移動方向を調整
        Vector3 moveDirection = cameraTransform.TransformDirection(lateralMove + forwardMove);
        moveDirection.y = 0; // y軸方向（上下）の移動は無視

        // 合成された移動ベクトルでRigidbodyの速度を設定
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        //ジャンプ
        if (jump.action.triggered && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
            jumpDelayFlg = true;
            StartCoroutine(JumpDalay());
            audioSource.clip = audioClipJump;
            audioSource.Play();
        }

        if (!jumpDelayFlg) StartCoroutine(GroundCheck());
    }

    private IEnumerator JumpDalay()
    {
        yield return new WaitForSeconds(jumpDelayTime);
        jumpDelayFlg = false;
        yield break;
    }

    private IEnumerator GroundCheck()
    {
        if (Physics.Raycast(this.transform.position, Vector3.down, out _, groundOffsetY, layerMask))
            isJumping = false;
        else isJumping = true;

        // 可視化用のデバッグラインを描画
        Debug.DrawRay(this.transform.position, Vector3.down * groundOffsetY, Color.red);

        yield break;
    }
}
