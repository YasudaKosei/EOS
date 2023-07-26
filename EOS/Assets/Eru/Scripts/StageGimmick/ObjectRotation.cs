using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;

    [SerializeField]
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
        if((int)axis == 0) transform.Rotate(Vector3.right * rotationSpeed);
        else if((int)axis == 1) transform.Rotate(Vector3.up * rotationSpeed);
        else transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.parent = this.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
