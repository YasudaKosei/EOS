using UnityEngine;
using UnityEngine.UI;

public class LocalizationTutorialText : MonoBehaviour
{
    [SerializeField,Header("元のテキスト")]
    private Text[] mainText;

    [SerializeField, Header("日本語")]
    private string[] textJP;

    [SerializeField, Header("英語")]
    private string[] textEN;

    void Update()
    {
        if (DisplayManager.JapaneseFlg) Japanese();
        else English();
    }

    private void Japanese()
    {
        for (int i = 0; i < mainText.Length; i++) mainText[i].text = textJP[i];
    }

    private void English()
    {
        for (int i = 0; i < mainText.Length; i++) mainText[i].text = textEN[i];
    }
}
