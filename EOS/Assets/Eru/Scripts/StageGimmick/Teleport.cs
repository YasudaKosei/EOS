using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField, Header("テレポート先")]
    private Vector3 teleportPos = new Vector3();

    [SerializeField, Header("プレイヤー指定")]
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
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)) other.gameObject.transform.position = teleportPos;
    }
}
