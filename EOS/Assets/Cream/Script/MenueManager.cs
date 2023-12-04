using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenueManager : MonoBehaviour
{
    //Pause
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private GameObject menue;

    private void Awake()
    {
        //設定を開くボタンを有効にする
        pause.action.Enable();
    }

    void Update()
    {
        if (pause.action.triggered)
        {
            MenueClick();
        }
    }

        //メニューを開く、閉じる
    public void MenueClick()
    {
        if (Stop.stopFlg == false)
        {
            Debug.Log("オプション表示");
            Set();
        }
        else
        {
            Debug.Log("オプション非表示");
            End();
        }
    }

    //メニューを開く
    public void Set()
    {
        menue.SetActive(true);
        Stop.stopFlg = true;
    }

    //メニューを閉じる
    public void End()
    {
        menue.SetActive(false);
        Stop.stopFlg = false;
    }

}
