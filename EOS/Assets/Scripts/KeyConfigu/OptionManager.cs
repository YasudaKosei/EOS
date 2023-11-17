using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class OptionManager : MonoBehaviour
{
    //設定のスクリプトです

    //Pause
    [SerializeField]
    private InputActionReference pause;

    //各設定キャンバスたち
    [SerializeField]
    private GameObject select,DisCan,keyCan,padCan,VolCan,OthCan;

    //ディスプレイのボタン
    [SerializeField]
    private Button DisButton;


    private void Awake()
    {
        //設定を開くボタンを有効にする
        pause.action.Enable();
    }

    void Update()
    {
        if (pause.action.triggered)
        {
            OptionClick();
        }
    }

    //設定を開く、閉じる
    public void OptionClick()
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

    //設定画面を開く
    public void Set()
    {
        select.SetActive(true);
        DisButton.onClick.Invoke();
        Stop.stopFlg = true;
    }

    //設定画面を閉じる
    public void End()
    {
        select.SetActive(false);
        CanvasSetFalse();
        Stop.stopFlg = false;
    }

    //ディスプレイ設定を開く
    public void DisplayCanvas()
    {
        CanvasSetFalse();
        DisCan.SetActive(true);
    }

    //キーボードの設定を開く
    public void KeyBoardCanvas()
    {
        CanvasSetFalse();
        keyCan.SetActive(true);
    }

    //ゲームパッドの設定を開く
    public void GamePadCanvas()
    {
        CanvasSetFalse();
        padCan.SetActive(true);
    }

    //音声の設定を開く
    public void VolumeCanvas()
    {
        CanvasSetFalse();
        VolCan.SetActive(true);
    }

    //その他の設定を開く
    public void OthersCanvas()
    {
        CanvasSetFalse();
        OthCan.SetActive(true);
    }

    //各設定のキャンバスを非表示
    private void CanvasSetFalse()
    {
        keyCan.SetActive(false);
        padCan.SetActive(false);
        DisCan.SetActive(false);
        VolCan.SetActive(false);
        OthCan.SetActive(false);
    }
}
