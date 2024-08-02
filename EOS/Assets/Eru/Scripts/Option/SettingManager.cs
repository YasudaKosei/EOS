using UnityEngine;
using UnityEngine.InputSystem;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private InputActionReference right;

    [SerializeField]
    private InputActionReference left;

    [SerializeField]
    private GameObject optionCan, disCan, souCan, keyCan, padCan, quitMenu;

    private bool optionOpenFlg = false;

    private int nowOpution = 1;

    private const int optionLeftBorder = 1;
    private const int optionRightBorder = 2;

    //public static OptionManager instance;

    private void Awake()
    {
        Stop.stopFlg = true;

        //キーの有効化
        pause.action.Enable();
        right.action.Enable();
        left.action.Enable();

        PanelUpdata();

        optionOpenFlg = false;
        optionCan.SetActive(optionOpenFlg);

        quitMenu.SetActive(false);
    }

    void Update()
    {
        //pauseキーが押されたら
        if (pause.action.triggered)
        {
            if (optionOpenFlg)
            {
                optionOpenFlg = false;
                optionCan.SetActive(optionOpenFlg);
            }
        }

        if (right.action.triggered && nowOpution < optionRightBorder && optionOpenFlg )
        {
            nowOpution++;
            PanelUpdata();
        }
        else if (left.action.triggered && nowOpution > optionLeftBorder && optionOpenFlg)
        {
            nowOpution--;
            PanelUpdata();
        }
    }

    private void PanelUpdata()
    {
        disCan.SetActive(false);
        souCan.SetActive(false);
        keyCan.SetActive(false);
        padCan.SetActive(false);

        switch (nowOpution)
        {
            case 1:
                disCan.SetActive(true);
                break;
            case 2:
                souCan.SetActive(true);
                break;
            case 3:
                keyCan.SetActive(true);
                break;
            case 4:
                padCan.SetActive(true);
                break;
        }
    }

    public void PanelChangeButton(int value)
    {
        if (nowOpution != value)
        {
            nowOpution = value;
            PanelUpdata();
        }
    }

    public void OptionOpenButton()
    {
        optionOpenFlg = true;
        optionCan.SetActive(optionOpenFlg);
    }

    public void OptionClauseButton()
    {
        optionOpenFlg = false;
        optionCan.SetActive(optionOpenFlg);
    }

    public void QuitMenuOpenButton()
    {
        quitMenu.SetActive(true);
    }

    public void QuitMenuClauseButton()
    {
        quitMenu.SetActive(false);
    }

    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                UnityEngine.Application.Quit();
#endif
    }
}
