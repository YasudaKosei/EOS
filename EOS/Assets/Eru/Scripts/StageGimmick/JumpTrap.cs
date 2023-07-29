using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    [SerializeField,Header("ジャンプ力")]
    private float jumpPower = 5f;

    [SerializeField,Header("プレイヤー指定")]
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
        //対象のプレイヤーか検知
        if (playerType != PlayerType.none && other.gameObject.tag != playerType.ToString()) return; 
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)) rb.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
    }
}
