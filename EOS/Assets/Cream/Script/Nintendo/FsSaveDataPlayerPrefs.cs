using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FsSaveDataPlayerPrefs : MonoBehaviour
{
    //SwitchでPlayerPrefsを使う

    public static FsSaveDataPlayerPrefs instance;


    private nn.account.Uid userId; // ユーザーID
    private const string mountName = "MySave"; // マウント名
    private const string fileName = "MySaveData"; // ファイル名
    private readonly string filePath = string.Format("{0}:/{1}", mountName, fileName); // ファイルパス 

#pragma warning disable 0414
    private nn.fs.FileHandle fileHandle = new nn.fs.FileHandle(); // ファイルハンドル
#pragma warning restore 0414

    private const string versionKey = "Version"; // バージョンキー

    private const int saveDataVersion = 1; // 保存データのバージョン

    private bool loadFlag = false;

    private bool isFinishedSplashScreenAndPassedUpdate = false;

    private bool moveScene = false;

    private void Start()
    {
        CheckInstance();
    }


    void CheckInstance()
    {
        //インスタンス化
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

#if !UNITY_SWITCH || UNITY_EDITOR

            InitializeSaveData();
            Load();

#else
            // アカウントシステムを初期化
            nn.account.Account.Initialize();

            // ユーザーハンドルの作成
            nn.account.UserHandle userHandle = new nn.account.UserHandle();

            // 事前選択されたユーザーを開く試み
            if (!nn.account.Account.TryOpenPreselectedUser(ref userHandle))
            {
                nn.Nn.Abort("Failed to open preselected user."); // 失敗した場合、アプリケーションを中断
            }

            // ユーザーIDを取得
            nn.Result result = nn.account.Account.GetUserId(ref userId, userHandle);

            // 失敗した場合、アプリケーションを中断
            result.abortUnlessSuccess();

            // セーブデータをマウント
            result = nn.fs.SaveData.Mount(mountName, userId);

            // 失敗した場合、アプリケーションを中断
            result.abortUnlessSuccess();

            // セーブデータの初期化
            InitializeSaveData();

            // セーブデータのロード
            Load();
#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (UnityEngine.Rendering.SplashScreen.isFinished)
        {
            // スプラッシュ画面が閉じUpdate関数を通過したかのフラグをtrueにする
            isFinishedSplashScreenAndPassedUpdate = true;
        }

        if (isFinishedSplashScreenAndPassedUpdate && !moveScene && loadFlag)
        {
            moveScene = true;
            SceneManager.LoadScene("Title");
        }
    }

    // 破棄時に実行されるメソッド
    private void OnDestroy()
    {
        // マウントを解除
        nn.fs.FileSystem.Unmount(mountName);
    }

    // セーブデータの初期化を行うメソッド
    public void InitializeSaveData()
    {
#if !UNITY_SWITCH || UNITY_EDITOR
        // 既にバージョンキーが存在する場合は初期化しない
        if (PlayerPrefs.HasKey(versionKey))
        {
            return;
        }

        // PlayerPrefsの初期化
        PlayerPrefs.SetInt(versionKey, saveDataVersion);
        PlayerPrefs.SetString("DisplayManager", "");
        PlayerPrefs.SetString("ChangeSoundVolume", "");
        PlayerPrefs.SetString("Save", "");

        // PlayerPrefsを保存
        PlayerPrefs.Save();
#else
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (result.IsSuccess())
        {
            return; // ファイルが既に存在する場合は初期化しない
        }
        if (!nn.fs.FileSystem.ResultPathNotFound.Includes(result))
        {
            result.abortUnlessSuccess(); // パスが見つからない以外のエラーがあった場合、アプリケーションを中断
        }

         // PlayerPrefsの初期化
         PlayerPrefs.SetInt(versionKey, saveDataVersion);
         PlayerPrefs.SetString("DisplayManager", "");
         PlayerPrefs.SetString("ChangeSoundVolume", "");
         PlayerPrefs.SetString("Save", "");

        byte[] data = UnityEngine.Switch.PlayerPrefsHelper.rawData; // 保存するデータを取得
        long saveDataSize = data.LongLength; // データサイズを取得

        UnityEngine.Switch.Notification.EnterExitRequestHandlingSection(); // 通知処理セクションの開始

        result = nn.fs.File.Create(filePath, saveDataSize); // ファイルを作成
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write); // 書き込みモードでファイルを開く
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        result = nn.fs.File.SetSize(instance.fileHandle, data.LongLength);
        result.abortUnlessSuccess();

        const int offset = 0;
        result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush); // データをファイルに書き込む
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        nn.fs.File.Close(fileHandle); // ファイルを閉じる
        result = nn.fs.FileSystem.Commit(mountName); // 変更をコミット
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection(); // 通知処理セクションの終了
#endif
    }


    // PlayerPrefsを保存するメソッド
    public void SavePlayerPrefs()
    {
#if !UNITY_SWITCH || UNITY_EDITOR
        // PlayerPrefsを保存
        PlayerPrefs.Save();
#else
        byte[] data = UnityEngine.Switch.PlayerPrefsHelper.rawData; // 保存するデータを取得
        long saveDataSize = data.LongLength; // データサイズを取得

        UnityEngine.Switch.Notification.EnterExitRequestHandlingSection(); // 通知処理セクションの開始

        nn.Result result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write); // 書き込みモードでファイルを開く
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        result = nn.fs.File.SetSize(instance.fileHandle, data.LongLength);
        result.abortUnlessSuccess();

        const int offset = 0;
        result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush); // データをファイルに書き込む
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        nn.fs.File.Close(fileHandle); // ファイルを閉じる
        result = nn.fs.FileSystem.Commit(mountName); // 変更をコミット
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection(); // 通知処理セクションの終了
#endif
    }


    // データを読み込むメソッド
    public void Load()
    {
#if !(!UNITY_SWITCH || UNITY_EDITOR)
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (nn.fs.FileSystem.ResultPathNotFound.Includes(result)) { return; } // ファイルが見つからない場合は読み込まない
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Read); // 読み込みモードでファイルを開く
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        long fileSize = 0;
        result = nn.fs.File.GetSize(ref fileSize, fileHandle); // ファイルサイズを取得
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        byte[] data = new byte[fileSize]; // ファイルサイズ分のバイト配列を作成
        result = nn.fs.File.Read(fileHandle, 0, data, fileSize); // ファイルからデータを読み込む
        result.abortUnlessSuccess(); // 失敗した場合、アプリケーションを中断

        nn.fs.File.Close(fileHandle); // ファイルを閉じる

        UnityEngine.Switch.PlayerPrefsHelper.rawData = data; // 読み込んだデータをPlayerPrefsHelperに設定

        loadFlag = true;

#endif
        // バージョンをPlayerPrefsから取得
        int version = PlayerPrefs.GetInt(versionKey);
        loadFlag = true;
    }
}