using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    void Start()
    {
        obj.SetActive(!GameData.tutorialFlg);
        GameData.tutorialFlg = true;
    }
}
