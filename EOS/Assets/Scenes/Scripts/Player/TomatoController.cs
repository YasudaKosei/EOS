using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoController : MonoBehaviour
{
    // 移動速度
    public float moveSpeed = 5;
    // ジャンプの強さ
    public float jumpPower = 3;
    // ロールの強さ
    public float rollForce = 10f;
    // 減速度
    public float deceleration = 3;

    // ジャンプに関連するInputActionReference
    [SerializeField]
    private InputActionReference jump;

    // 移動に関連するInputActionReference
    [SerializeField]
    private InputActionReference move;

    private Rigidbody rb;
    private bool isJumping = false;
    private bool jumpFlg = false;
    // ジャンプ時間のカウント
    private float jumpTimeCount = 0f;
    // ジャンプの最大持続時間
    private const float jumpTime = 0.3f;
    private Camera cam;
    private Transform cameraTransform;

    void Start()
    {
        // Rigidbodyコンポーネントの取得
        rb = GetComponent<Rigidbody>();

        // メインカメラの取得
        cam = Camera.main;
        // カメラのTransformコンポーネントの取得
        cameraTransform = cam.transform;

        // カメラコントローラにプレイヤーの位置とオフセットを設定
        cam.GetComponent<CameraController>().player = this.transform;
        cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;

        // ジャンプと移動のInputActionを有効化
        jump.action.Enable();
        move.action.Enable();
    }

    void Update()
    {
        // 移動
        Vector2 moveInput = move.action.ReadValue<Vector2>();
        // カメラの方向を考慮して移動方向を設定
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        // 移動方向を正規化して移動速度をかける
        moveDirection = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // ジャンプ
        if (jump.action.triggered && !isJumping)
        {
            // ジャンプ力を加える
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }

        // ジャンプ中の追加のジャンプ力
        if (jump.action.ReadValue<float>() > 0 && !jumpFlg)
        {
            // ジャンプボタンが押されている間、ジャンプ時間をカウント
            jumpTimeCount += Time.deltaTime;
        }
        else if (isJumping)
        {
            // ジャンプボタンが離された時に、ジャンプフラグを立てる
            jumpTimeCount = 0;
            jumpFlg = true;
        }

        if (jumpTimeCount <= jumpTime && !jumpFlg && isJumping)
        {
            // 一定時間内であれば追加のジャンプ力を加える
            rb.AddForce(Vector3.up * jumpPower * 0.1f, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 地面着地判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 地面に着地したらジャンプ関連のフラグやカウントをリセット
            isJumping = false;
            jumpFlg = false;
            jumpTimeCount = 0f;
        }
    }
}
