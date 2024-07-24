using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
    //現在のゲームのバージョンを取得するスクリプトです

    [SerializeField]
    private Text vText;

    void Start()
    {
        vText.text = "Version " + Application.version;

        if (SteamManager.Initialized)
        {
            // API初期化成功後（必須）

            if (SteamUserStats.RequestCurrentStats())
            {
                // ユーザーの現在のデータと実績を非同期に要求後（必須）

                // statsを更新
                SteamUserStats.SetAchievement("begin");
                // 更新を反映
                bool bSuccess = SteamUserStats.StoreStats();
            }
        }
    }
}

