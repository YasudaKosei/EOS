using Steamworks;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private DataManager dm;

    [SerializeField]
    private TimeManager tm;

    [SerializeField]
    private Text resultTimeText;

    [SerializeField]
    private Image[] starCoinImage;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private Sprite starSprite, noStarSprite;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private string sceneBGM;

    private int stageNum = 0;

    [SerializeField]
    private string[] easyAchv;

    [SerializeField]
    private string[] normalAchv;

    [SerializeField]
    private string[] starAchv;

    void Awake()
    {
        //非表示
        resultTimeText.enabled = false;
        for (int i = 0; i < starCoinImage.Length; i++) starCoinImage[i].enabled = false;
        button.SetActive(false);

        if (sceneBGM != null) BGMManager.instance.PlayBGM(sceneBGM);


        if (SceneManager.GetActiveScene().name == "Stage01") stageNum = 0;
        else if (SceneManager.GetActiveScene().name == "Stage02") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage03") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Stage04") stageNum = 3;
        else if (SceneManager.GetActiveScene().name == "Stage05") stageNum = 4;
        if (GameData.StageClearTime[stageNum] == 0 || GameData.StageClearTime[stageNum] > tm.ITimer) GameData.StageClearTime[stageNum] = tm.ITimer;

        dm.Save();
        SteamAchv();

        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        yield return new WaitForSeconds(0.5f);

        resultTimeText.text = tm.timeText.text;
        resultTimeText.enabled = true;
        //SE

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < starCoinImage.Length; i++)
        {
            starCoinImage[i].enabled = true;

            int starFlgsNum = (stageNum * 3) + i;
            if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum))) ==
            (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum)))
            {
                starCoinImage[i].sprite = starSprite;
                //SE
            }
            else
            {
                starCoinImage[i].sprite = noStarSprite;
                //SE
            }

            yield return new WaitForSeconds(0.5f);
        }

        button.SetActive(true);

        yield break;
    }

    private void SteamAchv()
    {
        string[] achvAPI;
        int starNum = 0;
        int starCount = 0;
        bool easyAchvFlg = true;
        bool normalAchvFlg = true;
        bool starAchvFlg = true;

        if (GameData.easyModeFlg)
        {
            achvAPI = new string[easyAchv.Length];
            for (int i = 0; i < easyAchv.Length; i++) achvAPI[i] = easyAchv[i];
        }
        else
        {
            achvAPI = new string[normalAchv.Length];
            for (int i = 0; i < normalAchv.Length; i++) achvAPI[i] = normalAchv[i];
        }

        for (int i = 0; i < starCoinImage.Length; i++)
        {
            int starFlgsNum = (stageNum * 3) + i;
            if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum))) ==
            (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum))) starNum++;
        }

        for (int i = 0; i < 5; i++) starCount += GameData.StageStarCount[i];

        for(int i=0;i<easyAchv.Length;i++)
        {
            SteamUserStats.GetAchievement(easyAchv[i], out easyAchvFlg);
            if (!easyAchvFlg) break;
        }

        for(int i=0;i< normalAchv.Length;i++)
        {
            SteamUserStats.GetAchievement(normalAchv[i], out normalAchvFlg);
            if (!normalAchvFlg) break;
        }

        for(int i=0;i< starAchv.Length;i++)
        {
            SteamUserStats.GetAchievement(starAchv[i], out starAchvFlg);
            if (!starAchvFlg) break;
        }

        if (SteamManager.Initialized)
        {
            // API初期化成功後（必須）

            if (SteamUserStats.RequestCurrentStats())
            {
                // ユーザーの現在のデータと実績を非同期に要求後（必須）

                // statsを更新
                SteamUserStats.SetAchievement(achvAPI[stageNum]);

                // 更新を反映
                SteamUserStats.StoreStats();

                if (starNum >= 3) SteamUserStats.SetAchievement(starAchv[stageNum]);

                // 更新を反映
                SteamUserStats.StoreStats();

                if (starCount >= 9) SteamUserStats.SetAchievement("beginend");

                // 更新を反映
                SteamUserStats.StoreStats();

                if (easyAchvFlg) SteamUserStats.SetAchievement("king");

                // 更新を反映
                SteamUserStats.StoreStats();

                if (normalAchvFlg) SteamUserStats.SetAchievement("legend");

                // 更新を反映
                SteamUserStats.StoreStats();

                if (easyAchvFlg && normalAchvFlg && starAchvFlg) SteamUserStats.SetAchievement("how");

                // 更新を反映
                SteamUserStats.StoreStats();
            }
        }
    }
}
