using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField, Header("�e���|�[�g��")]
    private Vector3 teleportPos = new Vector3();

    [SerializeField, Header("�v���C���[�w��")]
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
        if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)) other.gameObject.transform.position = teleportPos;
    }
}
