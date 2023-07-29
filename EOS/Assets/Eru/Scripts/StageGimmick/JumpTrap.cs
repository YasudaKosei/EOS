using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    [SerializeField,Header("�W�����v��")]
    private float jumpPower = 5f;

    [SerializeField,Header("�v���C���[�w��")]
    private PlayerType playerType;

    private enum PlayerType
    {
        none,
        Tomato,
        Pot,
        Broccoli,
        Carrot,
        Watermelon,
    }

    private void OnTriggerEnter(Collider other)
    {
        //�Ώۂ̃v���C���[�����m
        if (playerType != PlayerType.none && other.gameObject.tag != playerType.ToString()) return; 
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)) rb.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
    }
}
