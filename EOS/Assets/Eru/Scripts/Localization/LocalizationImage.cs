using UnityEngine;
using UnityEngine.UI;

public class LocalizationImage : MonoBehaviour
{
    [SerializeField, Header("元画像")]
    private Image[] image = new Image[31];

    [SerializeField, Header("日本語画像")]
    private Sprite[] spriteJP = new Sprite[31];

    [SerializeField, Header("英語画像")]
    private Sprite[] spriteEN = new Sprite[31];

    void Update()
    {
        if (DisplayManager.JapaneseFlg) Japanese();
        else English();
    }

    private void Japanese()
    {
        for(int i = 0;i< image.Length; i++) image[i].sprite = spriteJP[i];
    }

    private void English()
    {
        for (int i = 0; i < image.Length; i++) image[i].sprite = spriteEN[i];
    }
}
