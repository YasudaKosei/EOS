using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testjump : MonoBehaviour
{
    [SerializeField]
    Rigidbody rigidBody;
    [SerializeField, Min(0)]
    float jumpPower = 5f;
    [SerializeField]
    AnimationCurve jumpCurve = new();
    [SerializeField, Min(0)]
    float maxJumpTime = 1f;
    [SerializeField]
    float groundCheckRadius = 0.4f;
    [SerializeField]
    float groundCheckOffsetY = 0.45f;
    [SerializeField]
    float groundCheckDistance = 0.2f;
    [SerializeField]
    LayerMask groundLayers = 0;
    [SerializeField]
    string JumpButtonName = "Jump";

    bool isGrounded = false;
    bool jumping = false;
    float jumpTime = 0;
    RaycastHit hit;
    Transform thisTransform;

    void Start()
    {
        thisTransform = transform;
    }

    void Update()
    {
        // SphereCastを実行し、結果をhitに格納
        bool grounded = Physics.SphereCast(thisTransform.position + groundCheckOffsetY * Vector3.up, groundCheckRadius, Vector3.down, out hit, groundCheckDistance, groundLayers, QueryTriggerInteraction.Ignore);

        // 可視化用のデバッグラインを描画
        Debug.DrawRay(thisTransform.position + groundCheckOffsetY * Vector3.up, Vector3.down * groundCheckDistance, grounded ? Color.green : Color.red);
    }
}
