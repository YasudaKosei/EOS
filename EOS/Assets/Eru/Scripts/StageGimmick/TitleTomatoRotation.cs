using UnityEngine;

public class TitleTomatoRotation : MonoBehaviour
{
    [SerializeField, Header("回転速度")]
    private float rotationSpeed = 5f;

    [SerializeField, Header("回転軸")]
    private XYZ axis;

    public enum XYZ
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    void Update()
    {
        //X軸
        if ((int)axis == 0) transform.Rotate(Vector3.right * rotationSpeed);

        //Y軸
        else if ((int)axis == 1) transform.Rotate(Vector3.up * rotationSpeed);

        //Z軸
        else transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //親子関係にする
        collision.gameObject.transform.parent = this.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        //親子関係破棄
        collision.gameObject.transform.parent = null;
    }
}
