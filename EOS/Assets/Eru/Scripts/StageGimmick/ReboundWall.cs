using UnityEngine;

public class ReboundWall : MonoBehaviour
{
    [SerializeField,Header("反発力")]
    private float reboundPower = 5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(playerType.ToString()) && playerType != PlayerType.none) return;

        //跳ね返されている最中は動けないようにする
        if (collision.gameObject.TryGetComponent<TomatoController>(out TomatoController tc)) tc.knockBackFlg = true;
        if (collision.gameObject.TryGetComponent<CarrotController>(out CarrotController cc)) cc.knockBackFlg = true;
        if (collision.gameObject.TryGetComponent<BroccoliController>(out BroccoliController bc)) bc.knockBackFlg = true;
        if (collision.gameObject.TryGetComponent<WatermelonController>(out WatermelonController wc)) wc.knockBackFlg = true;

        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            // プレイヤーの進行方向に応じて跳ね返す向きを計算
            Vector3 direction = (collision.contacts[0].point - this.transform.position).normalized;
            direction.y = 0f;
            rb.AddForce(direction * reboundPower, ForceMode.Impulse);
        }
    }
}
