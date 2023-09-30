using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField, Header("��]���x")]
    private float rotationSpeed = 5f;

    [SerializeField,Header("��]��")]
    private XYZ axis;
    
    public enum XYZ
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    void Update()
    {
        if (Stop.stopFlg) return;

        //X��
        if ((int)axis == 0) transform.Rotate(Vector3.right * rotationSpeed);

        //Y��
        else if ((int)axis == 1) transform.Rotate(Vector3.up * rotationSpeed);

        //Z��
        else transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�e�q�֌W�ɂ���
        collision.gameObject.transform.parent = this.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        //�e�q�֌W�j��
        collision.gameObject.transform.parent = null;
    }
}
