using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private DataManager data;

    void Start()
    {
        data.Read();
        obj.SetActive(!GameData.tutorialFlg);
        GameData.tutorialFlg = true;
        data.Save();
    }
}
