using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.IO;
using System;

public class RankingManager : MonoBehaviour
{
    private string playerID;

    public GameObject rankingPrefab;
    public Transform rankingPos;
    public Transform myrankingPos;
    private RPmanager rPmanager;

    void Start()
    {
        Login();
        SetRanking();
    }

    void Update()
    {
        
    }

    private void Login()
    {
        PlayFabSettings.staticSettings.TitleId = "9BC90"; // TitleIDを設定

        //ログイン作業(初回ログイン処理も含む)
        string customIdPath = Path.Combine(Application.persistentDataPath, "customId.txt");
        string customId;
        if (File.Exists(customIdPath))
        {
            customId = File.ReadAllText(customIdPath);
        }
        else
        {
            customId = Guid.NewGuid().ToString();
            File.WriteAllText(customIdPath, customId);
        }
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
        {
            CustomId = customId,
        }, result =>
        {
            playerID = customId;
            Debug.Log("ログイン成功 IDは " + result.PlayFabId);

        }, error =>
        {
            Debug.Log("ログインエラー");
        });
    }


    //週間ランキングを更新ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void SetRanking()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TimeRanking", // 取得したいランキングの名前を指定
            StartPosition = 0, // ランキングデータの取得を開始する位置を指定
            MaxResultsCount = 100
        };

        PlayFabClientAPI.GetLeaderboard(request, OnGetMonthlyLeaderboardSuccess, OnGetMonthlyLeaderboardFailure);
    }

    private void OnGetMonthlyLeaderboardSuccess(GetLeaderboardResult result)
    {
        // トランスフォームに含まれるすべての子オブジェクトを取得する
        foreach (Transform child in rankingPos)
        {
            // 子オブジェクトを削除する
            GameObject.Destroy(child.gameObject);
        }

        // トランスフォームに含まれるすべての子オブジェクトを取得する
        foreach (Transform child in myrankingPos)
        {
            // 子オブジェクトを削除する
            GameObject.Destroy(child.gameObject);
        }

        MySetMonthlyranking(playerID);

        int rankVal = 1;
        foreach (var item in result.Leaderboard)
        {
            GameObject RankObj = (GameObject)Instantiate(rankingPrefab, rankingPos);

            rPmanager = RankObj.GetComponent<RPmanager>();

            rPmanager.StartRankText(rankVal++, item.DisplayName, item.StatValue, "0000");

        }
    }

    private void OnGetMonthlyLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError("ランキングデータの取得に失敗: " + error.ErrorMessage);
    }


    //自分のランキングを取得
    private void MySetMonthlyranking(string playerId)
    {
        GetLeaderboardAroundPlayerRequest request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "TimeRanking",
            PlayFabId = playerID,
            MaxResultsCount = 1
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetMonthLeaderboardAroundPlayerSuccess, OnGetMonthLeaderboardAroundPlayerFailure);
    }

    private void OnGetMonthLeaderboardAroundPlayerSuccess(GetLeaderboardAroundPlayerResult result)
    {
        // ランキングデータの取得に成功した場合の処理

        // プレイヤーの順位を取得
        int rankVal = result.Leaderboard[0].Position + 1;
        int StatValue = result.Leaderboard[0].StatValue;
        string DisplayName = result.Leaderboard[0].DisplayName;


        GameObject RankObj = (GameObject)Instantiate(rankingPrefab, myrankingPos);

        rPmanager = RankObj.GetComponent<RPmanager>();

        rPmanager.StartRankText(rankVal, DisplayName, StatValue, "0000");

    }

    private void OnGetMonthLeaderboardAroundPlayerFailure(PlayFabError error)
    {
        // ランキングデータの取得に失敗した場合の処理
        Debug.Log("Failed to get leaderboard data: " + error.ErrorMessage);
    }
    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
}
