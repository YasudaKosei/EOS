using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuCan;

    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private GameObject quitMenuUI;

    private bool openFlg = false;

    void Start()
    {
        openFlg = false;
        quitMenuUI.SetActive(false);
        pause.action.Enable();
    }

    void Update()
    {
        if (pause.action.triggered)
        {
            openFlg = !openFlg;
        }
        Stop.stopFlg = openFlg;

        menuCan.SetActive(openFlg);
    }

    public void SettingsOpen()
    {

    }

    public void CloceMenu()
    {
        openFlg = false;
    }

    public void QuitMenu(bool value)
    {
        quitMenuUI.SetActive(value);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
