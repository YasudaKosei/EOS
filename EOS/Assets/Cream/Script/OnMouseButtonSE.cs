using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseButtonSE : MonoBehaviour, IPointerEnterHandler
{
    private Button myButton;

    void Start()
    {
        // GetComponentを使ってButtonコンポーネントを取得
        myButton = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (myButton.interactable)
        {
            Debug.Log("mouseがボタンに重なりました");
            SEManager.instance.PlaySE("OMB");
        }
    }
}
