using UnityEngine;

public class WindArea : MonoBehaviour
{
    [SerializeField, Header("風の力")]
    private float windPower;

    [SerializeField, Header("風の向き")]
    private FBLR direction;

    [SerializeField, Header("プレイヤー指定")]
    private PlayerType playerType;

    private enum FBLR
    {
        front,
        back,
        left,
        right,
    }

    private enum PlayerType
    {
        none,
        Tomato,
        Pot,
        Broccoli,
        Carrot,
        Watermelon,
    }

    private void OnTriggerStay(Collider other)
    {
        //対象のプレイヤーか検知
        if (playerType != PlayerType.none && other.gameObject.tag != playerType.ToString()) return;
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            if (direction == FBLR.front) rb.AddForce(Vector3.forward * windPower, ForceMode.Impulse);
            if (direction == FBLR.back) rb.AddForce(Vector3.back * windPower, ForceMode.Impulse);
            if (direction == FBLR.left) rb.AddForce(Vector3.left * windPower, ForceMode.Impulse);
            if (direction == FBLR.right) rb.AddForce(Vector3.right * windPower, ForceMode.Impulse);
        }
    }
}
