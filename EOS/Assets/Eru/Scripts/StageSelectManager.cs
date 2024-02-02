using UnityEngine;
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

    private void Start()
    {
        Stop.stopFlg = true;
        int total = 0;
        for (int i = 0; i < 5; i++)
        {
            total += GameData.StageStarCount[i];

            getStageStarText[i].text = "★3/" + GameData.StageStarCount[i].ToString();
            if (GameData.StageClearTime[i] == 0) clearStageTimeText[i].text = "Clear Time\n-- : --";
            else clearStageTimeText[i].text = "Clear Time\n" + (GameData.StageClearTime[i] / 60).ToString("d2") + " : " + (GameData.StageClearTime[i] % 60).ToString("d2");
        }

        totalStarText.text = "★×" + total.ToString();

        if (total >= unlockNum) stage5Button.interactable = true;
        else stage5Button.interactable = false;
        unlockText.enabled = stage5Button.interactable;
    }
}
