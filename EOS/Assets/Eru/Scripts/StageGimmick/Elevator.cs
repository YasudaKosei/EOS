using UnityEngine;
using System.Linq;

public class Elevator : MonoBehaviour
{
    [SerializeField, Header("�ړ���")]
    private Vector3[] movetPos;

    [SerializeField,Header("�ړ����x")]
    private float moveSpeed = 5f;

    [SerializeField, Header("���[�v")]
    private bool loopFlg = false;

    [SerializeField, Header("�v���C���[�w��")]
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
        startPos = this.transform.position;
        movetPos = movetPos.Prepend<Vector3>(startPos).ToArray();

        back = 1;

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

    private void ReturnInit()
    {
        if(nextMovePoint != 0 && Vector3.Distance(this.transform.position, movetPos[nextMovePoint]) <= 0.1f) nextMovePoint += back;
        Vector3 direction = (movetPos[nextMovePoint] - this.transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void MoveNext()
    {
        Vector3 direction = (movetPos[nextMovePoint] - this.transform.position).normalized;

        // �I�u�W�F�N�g�̈ʒu���ڕW���W�ɏ\���߂Â�����ړ����I��
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

        // �����x�N�g�����g���ăI�u�W�F�N�g���ړ�������
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb) && collision.gameObject.tag == playerType.ToString())
        {
            moveFlg = true;
            collision.transform.parent = this.transform;
            if (nextMovePoint < movetPos.Length - 1) nextMovePoint++;
            back = 1;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != playerType.ToString() && collision.gameObject == null && playerType != PlayerType.none) moveFlg = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
        if (playerType != PlayerType.none)
        {
            moveFlg = false;
            if (back < 0) return;
            back = -1;
            if (nextMovePoint != 0) nextMovePoint += back;
        }
    }
}
