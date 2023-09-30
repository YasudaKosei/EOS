using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField, Header("âÒì]ë¨ìx")]
    private float rotationSpeed = 5f;

    [SerializeField,Header("âÒì]é≤")]
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

        //Xé≤
        if ((int)axis == 0) transform.Rotate(Vector3.right * rotationSpeed);

        //Yé≤
        else if ((int)axis == 1) transform.Rotate(Vector3.up * rotationSpeed);

        //Zé≤
        else transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //êeéqä÷åWÇ…Ç∑ÇÈ
        collision.gameObject.transform.parent = this.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        //êeéqä÷åWîjä¸
        collision.gameObject.transform.parent = null;
    }
}
