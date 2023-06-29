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
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }
    void OnEnable()
    {
        PlayFabAuthService.OnLoginSuccess += PlayFabLogin_OnLoginSuccess;
    }
    private void PlayFabLogin_OnLoginSuccess(LoginResult result)
    {
        SetRanking();
        Debug.Log("Login Success!");
    }

    //ランキングを取得
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

            rPmanager.StartRankText(rankVal++, item.DisplayName, item.StatValue);

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

        rPmanager.StartRankText(rankVal, DisplayName, StatValue);

    }

    private void OnGetMonthLeaderboardAroundPlayerFailure(PlayFabError error)
    {
        // ランキングデータの取得に失敗した場合の処理
        Debug.Log("Failed to get leaderboard data: " + error.ErrorMessage);
    }
}
