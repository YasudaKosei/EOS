using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private Button stage5Button;

    [SerializeField]
    private Text[] getStageStarText;

    [SerializeField]
    private Text[] clearStageTimeText;

    [SerializeField]
    private Text totalStarText;

    [SerializeField]
    private Text unlockText;

    [SerializeField]
    private int unlockNum = 9;

    [SerializeField]
    private GameObject modeObj;

    [SerializeField]
    private InputActionReference pause;

    private int stageNum = 0;

    private SceneSelectManager sceneSelect;

    private void Start()
    {
        Stop.stopFlg = true;
        modeObj.SetActive(false);
        sceneSelect = this.gameObject.GetComponent<SceneSelectManager>();

        int total = 0;
        for (int i = 0; i < 5; i++)
        {
            total += GameData.StageStarCount[i];

            getStageStarText[i].text = "★" + GameData.StageStarCount[i].ToString() + "/3";
            if (GameData.StageClearTime[i] == 0) clearStageTimeText[i].text = "Clear Time\n-- : --";
            else clearStageTimeText[i].text = "Clear Time\n" + (GameData.StageClearTime[i] / 60).ToString("d2") + " : " + (GameData.StageClearTime[i] % 60).ToString("d2");
        }

        totalStarText.text = "★×" + total.ToString();

        if (total >= unlockNum) stage5Button.interactable = true;
        else stage5Button.interactable = false;
        unlockText.enabled = !stage5Button.interactable;

        pause.action.Enable();
    }

    private void Update()
    {
        if(pause.action.triggered) modeObj.SetActive(false);
    }

    public void StageSelectButton(int value)
    {
        stageNum = value;
        modeObj.SetActive(true);
    }

    public void ModeButton(bool value)
    {
        GameData.easyModeFlg = value;
        sceneSelect.SceneLoad(stageNum);
    }
}
