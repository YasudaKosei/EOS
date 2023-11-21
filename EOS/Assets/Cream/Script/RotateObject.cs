using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // 回転の方向を設定するためのPublic変数
    public Vector3 rotationDirection = Vector3.up; // デフォルトは上向き（y軸周り）

    // 回転スピードを設定するためのPublic変数
    public float rotationSpeed = 10f; // デフォルトのスピード

    void Update()
    {
        // オブジェクトを回転させる
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
