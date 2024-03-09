using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    void Start()
    {
        obj.SetActive(!GameData.tutorialFlg);
    }


    public void LanguageButton(bool value)
    {
        DisplayManager.JapaneseFlg = value;
        obj.SetActive(false);
    }
}
