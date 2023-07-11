using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBObj : MonoBehaviour
{
    public float jb = 30.0f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>(); // rigidbodyを取得
        Vector3 force = new Vector3(0.0f, jb, 0.0f);    // 力を設定
        rb.AddForce(force, ForceMode.Impulse);    // 力を加える
    }
}
