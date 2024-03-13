using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private Dropdown dropdown;

    void Start()
    {
        obj.SetActive(!GameData.tutorialFlg);
    }


    public void LanguageButton(bool value)
    {
        DisplayManager.JapaneseFlg = value;
        obj.SetActive(false);
        if (value) dropdown.value = 0;
        else dropdown.value = 1;
    }
}
