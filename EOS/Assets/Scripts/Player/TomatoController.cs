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

    [HideInInspector]
    public bool isJumping = false;

    [SerializeField]
    private InputActionReference jump;
    
    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private InputActionReference skill;

    [SerializeField]
    private float movementThreshold = 3f;

    private Rigidbody rb;
    private float lateralmoveSpeed;
    private Camera cam;
    private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cameraTransform = cam.transform;
        cam.GetComponent<FrameRate>().player = this.transform;
        jump.action.Enable();
        move.action.Enable();
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

        //ジャンプ時の左右ストレイフ制御
        //if(!isJumping)
        //{
        //    lateralmoveSpeed = moveSpeed;
        //}
        //else 
        //{
        //    lateralmoveSpeed = moveSpeed/ downMoveSpeed;
        //}
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

        //Skill＼(^o^)／
        if (skill.action.triggered)
        {
            if(Skill.skillFlg == true && Skill.nowSkill == false)
            {
                Skill.nowSkill = true;
                StartCoroutine(TomatoSkill());
            }
             else
            {
                Debug.Log("スキルは現在使えません");
            }
        }


        //ジャンプ
        if (jump.action.triggered && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }
         
    }

    IEnumerator TomatoSkill()
    {
        Debug.Log("トマトskill発動");
        moveSpeed *= skillUpVal;
        yield return new WaitForSeconds(skillTime);
        moveSpeed /= skillUpVal;
        Debug.Log("トマトskill終了");
        Skill.skillFlg = false;
        Skill.nowSkill = false;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    //地面着地判定
    //    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Elevator"))
    //    {
    //        isJumping = false;
    //    }
    //    if (collision.gameObject.CompareTag("Elevator")) pc.elevatorFlg = true;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Elevator")) pc.elevatorFlg = false;
    //}
}
