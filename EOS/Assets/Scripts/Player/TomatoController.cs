using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TomatoController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float dashSpeed = 1.5f;
    public float jumpPower = 3;
    public float rollForce = 10f;
    public float deceleration = 3;

    public float skillTime = 5;
    public float skillUpVal = 2;

    [HideInInspector]
    public PC pc;

    [HideInInspector]
    public bool knockBackFlg = false;

    [HideInInspector]
    public bool isJumping = false;

    [SerializeField]
    private InputActionReference jump;
    
    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private InputActionReference dash;

    [SerializeField]
    private InputActionReference skill;

    [SerializeField]
    private float movementThreshold = 3f;

    private Rigidbody rb;
    private bool jumpFlg = false;
    private bool skillFlg = false;
    private float jumpTimeCount = 0f;
    private const float jumpTime = 0.3f;
    private Camera cam;
    private Transform cameraTransform;

    void Start()
    {
        //クールダウン追加するまでは
        skillFlg = true;

        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cameraTransform = cam.transform;
        cam.GetComponent<CameraController>().player = this.transform;
        //cam.GetComponent<CameraController>().offset = cam.transform.position - this.transform.position;
        jump.action.Enable();
        move.action.Enable();
        dash.action.Enable();
        skill.action.Enable();
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

        //Skill＼(^o^)／
        if (skill.action.triggered && skillFlg)
        {
            skillFlg = false;
            StartCoroutine(TomatoSkill());
        }

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

    IEnumerator TomatoSkill()
    {
        Debug.Log("トマトskill発動");
        moveSpeed *= skillUpVal;
        yield return new WaitForSeconds(skillTime);
        moveSpeed /= skillUpVal;
        Debug.Log("トマトskill終了");
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

        //エフェクト出す
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elevator")) pc.elevatorFlg = false;
    }
}
