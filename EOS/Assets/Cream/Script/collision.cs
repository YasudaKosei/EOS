using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    /// <summary>
    /// �ړ����̃R���C�_�[��obj�ɐG�ꂽ���̏���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Tomato"))
        {
            // �G�ꂽobj�̐e���ړ����ɂ���
            other.transform.SetParent(transform);
        }*/

        other.transform.SetParent(transform);

    }

    /// <summary>
    /// �ړ����̃R���C�_�[��obj���痣�ꂽ���̏���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        /*  if (other.gameObject.CompareTag("Tomato"))
          {
              // �G�ꂽobj�̐e���Ȃ���
              other.transform.SetParent(null);
          }*/

        other.transform.SetParent(null);
    }
}
