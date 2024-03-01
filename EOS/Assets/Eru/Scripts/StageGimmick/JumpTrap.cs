using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    [SerializeField, Header("ジャンプ力")]
    private float jumpPower = 5f;

    [SerializeField, Header("プレイヤー指定")]
    private PlayerType playerType;

    [SerializeField, Header("SE")]
    private AudioClip clip;

    private new AudioSource audio;

    private enum PlayerType
    {
        none,
        Player,
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
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
            audio = other.gameObject.GetComponent<AudioSource>();
            audio.clip = clip;
            audio.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //対象のプレイヤーか検知
        if (playerType != PlayerType.none && collision.gameObject.tag != playerType.ToString()) return;
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
            audio = collision.gameObject.GetComponent<AudioSource>();
            audio.clip = clip;
            audio.Play();
        }
    }
}
