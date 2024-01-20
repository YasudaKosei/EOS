using UnityEngine;
using System.Linq;

public class Elevator : MonoBehaviour
{
    [SerializeField, Header("移動先")]
    private Vector3[] movetPos;

    [SerializeField,Header("移動速度")]
    private float moveSpeed = 5f;

    [SerializeField, Header("ループ")]
    private bool loopFlg = false;

    [SerializeField, Header("プレイヤー指定")]
    private PlayerType playerType;

    private bool moveFlg = false;

    private Vector3 startPos;

    private int nextMovePoint = 0;

    private int back = 1;

    private enum PlayerType
    {
        none,
        Tomato,
        Pot,
        Broccoli,
        Carrot,
        Watermelon,
    }

    private void Start()
    {
        //初期値を配列の先頭に追加
        startPos = this.transform.position;
        movetPos = movetPos.Prepend<Vector3>(startPos).ToArray();

        back = 1;
        nextMovePoint = 1;

        if (playerType == PlayerType.none) moveFlg = true;
        else moveFlg = false;
    }

    private void Update()
    {
        if (Stop.stopFlg) return;

        if (!moveFlg && Vector3.Distance(startPos, this.transform.position) <= 0.1f) return;
        else if (!moveFlg) ReturnInit();
        else MoveNext();
    }

    /// <summary>
    /// 初期地に戻る
    /// </summary>
    private void ReturnInit()
    {
        if(nextMovePoint != 0 && Vector3.Distance(this.transform.position, movetPos[nextMovePoint]) <= 0.1f) nextMovePoint += back;
        Vector3 direction = (movetPos[nextMovePoint] - this.transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// 次の移動先に移動
    /// </summary>
    private void MoveNext()
    {
        Vector3 direction = (movetPos[nextMovePoint] - this.transform.position).normalized;

        // オブジェクトの位置が目標座標に十分近づいたら次の移動先へ移動するようにする
        if (Vector3.Distance(this.transform.position, movetPos[nextMovePoint]) <= 0.1f)
        {
            if (loopFlg)
            {
                nextMovePoint++;
                if(nextMovePoint > movetPos.Length - 1) nextMovePoint = 0;
            }
            else
            {
                if (nextMovePoint == movetPos.Length - 1 || nextMovePoint == 0) back *= -1;
                nextMovePoint += back;
            }
        }

        // オブジェクトを移動
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Oncoll");
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            //親子関係にする
            collision.transform.parent = this.transform;

            if(collision.gameObject.tag == playerType.ToString())
            {
                //移動を開始
                moveFlg = true;
                if (nextMovePoint < movetPos.Length - 1) nextMovePoint++;
                back = 1;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //親子関係破棄
        collision.transform.parent = null;

        if (playerType != PlayerType.none)
        {
            //移動停止及び帰還
            moveFlg = false;
            if (back < 0) return;
            back = -1;
            if (nextMovePoint != 0) nextMovePoint += back;
        }
    }
}
