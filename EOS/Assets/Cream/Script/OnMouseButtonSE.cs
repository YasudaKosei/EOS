using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseButtonSE : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mouseがボタンに重なりました");
        SEManager.instance.PlaySE("OMB");
    }
}
