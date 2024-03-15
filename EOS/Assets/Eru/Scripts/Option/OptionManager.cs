using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OptionManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private InputActionReference right;

    [SerializeField]
    private InputActionReference left;

    [SerializeField]
    private InputActionReference res;

    [SerializeField]
    private DataManager dm;

    [SerializeField]
    private PC pc;

    [SerializeField]
    private GameObject settingCan, optionCan, disCan, souCan, keyCan, padCan, quitMenu;

    private bool settingOpenFlg = false;
    private bool optionOpenFlg = false;

    private int nowOpution = 1;

    private const int optionLeftBorder = 1;
    private const int optionRightBorder = 4;

    [HideInInspector]
    public bool goalFlg = false;

    //public static OptionManager instance;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else Destroy(this.gameObject);

        //キーの有効化
        pause.action.Enable();
        right.action.Enable();
        left.action.Enable();
        res.action.Enable();

        PanelUpdata();

        settingOpenFlg = false;
        optionOpenFlg = false;
        goalFlg = false;
        settingCan.SetActive(settingOpenFlg);
        optionCan.SetActive(optionOpenFlg);

        quitMenu.SetActive(false);
    }

    void Update()
    {
        if (goalFlg) return;

        //pauseキーが押されたら
        if (pause.action.triggered)
        {
            if (!optionOpenFlg)
            {
                settingOpenFlg = !settingOpenFlg;
                settingCan.SetActive(settingOpenFlg);
            }
            else if (optionOpenFlg)
            {
                optionOpenFlg = false;
                optionCan.SetActive(optionOpenFlg);
            }
            Stop.stopFlg = settingOpenFlg;
        }

        if (!optionOpenFlg && res.action.triggered && !Stop.stopFlg) Retry();

        if (right.action.triggered && nowOpution < optionRightBorder && optionOpenFlg)
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

    public void GameBackButton()
    {
        settingOpenFlg = false;
        Stop.stopFlg = settingOpenFlg;
        settingCan.SetActive(settingOpenFlg);
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

    public void TitleBackButton()
    {
        dm.Save();
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitMenuOpenButton()
    {
        quitMenu.SetActive(true);
    }

    public void QuitMenuClauseButton()
    {
        quitMenu.SetActive(false);
    }

    public void Retry()
    {
        pc.PlayerRespawn();
        GameBackButton();
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
