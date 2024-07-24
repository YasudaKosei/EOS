//セーブするための項目

[System.Serializable]
public class SaveData
{
    public int[] StageStarCount = new int[5];

    public int[] StageClearTime = new int[5];

    public StageStarManager.StageStar stageStar;

    public bool easyModeFlg = false;

    public bool tutorialFlg = false;

    public float distance = 6.0f;
}