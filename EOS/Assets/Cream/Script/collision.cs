using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    /// <summary>
    /// 移動床のコライダーがobjに触れた時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Tomato"))
        {
            // 触れたobjの親を移動床にする
            other.transform.SetParent(transform);
        }*/

        other.transform.SetParent(transform);

    }

    /// <summary>
    /// 移動床のコライダーがobjから離れた時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        /*  if (other.gameObject.CompareTag("Tomato"))
          {
              // 触れたobjの親をなくす
              other.transform.SetParent(null);
          }*/

        other.transform.SetParent(null);
    }
}
