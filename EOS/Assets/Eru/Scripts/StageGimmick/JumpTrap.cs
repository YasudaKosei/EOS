using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)) rb.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
    }
}
