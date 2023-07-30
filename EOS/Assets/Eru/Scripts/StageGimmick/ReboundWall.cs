using UnityEngine;

public class ReboundWall : MonoBehaviour
{
    [SerializeField,Header("������")]
    private float reboundPower = 5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != playerType.ToString() && playerType != PlayerType.none) return;

        //���˕Ԃ���Ă���Œ��͓����Ȃ��悤�ɂ���
        if (collision.gameObject.TryGetComponent<TomatoController>(out TomatoController tc)) tc.knockBackFlg = true;
        if (collision.gameObject.TryGetComponent<PotController>(out PotController po)) po.knockBackFlg = true;

        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            // �v���C���[�̐i�s�����ɉ����Ē��˕Ԃ��������v�Z
            Vector3 direction = (collision.contacts[0].point - this.transform.position).normalized;
            direction.y = 0f;
            rb.AddForce(direction * reboundPower, ForceMode.Impulse);
        }
    }
}
