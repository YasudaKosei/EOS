using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    [SerializeField, Header("スクリーンモードドロップダウン")]
    private Dropdown screenDropDown;

    [SerializeField, Header("解像度ドロップダウン")]
    private Dropdown resolutionDropDown;

    [SerializeField, Header("言語ドロップダウン")]
    private Dropdown languageDropDown;

    [SerializeField, Header("解像度テキスト")]
    private Text resolutionText;

    [SerializeField, Header("X軸感度スライダー")]
    private Slider sliderX;

    [SerializeField, Header("X軸感度インプットフィールド")]
    private InputField inputFieldX;

    [SerializeField, Header("X軸感度トグル")]
    private Toggle toggleX;

    [SerializeField, Header("Y軸感度スライダー")]
    private Slider sliderY;

    [SerializeField, Header("Y軸感度インプットフィールド")]
    private InputField inputFieldY;

    [SerializeField, Header("Y軸感度トグル")]
    private Toggle toggleY;

    private int width = 1920;
    private int height = 1080;
    private bool screenModeFlg = true;
    public static float sensitivityX = 3.0f;
    public static float sensitivityY = 2.0f;
    public static bool inversionX = false;
    public static bool inversionY = true;
    public static bool JapaneseFlg = true;

    void Start()
    {
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }

    /// <summary>
    /// スクリーンモード変更
    /// </summary>
    public void ChangeScreenMode()
    {
        //フルスクリーンモード
        if (screenDropDown.value == 0) screenModeFlg = true;

        //ウィンドウモード
        else if (screenDropDown.value == 1) screenModeFlg = false;

        //更新
        ChangeDisplay();
    }

    /// <summary>
    /// 解像度変更
    /// </summary>
    public void ChangeResolution()
    {
        //1920 * 1080
        if (resolutionDropDown.value == 0)
        {
            width = 1920;
            height = 1080;
        }

        //1680 * 1050
        else if (resolutionDropDown.value == 1)
        {
            width = 1680;
            height = 1050;
        }

        //1440 * 1080
        else if (resolutionDropDown.value == 2)
        {
            width = 1440;
            height = 1080;
        }

        //1280 * 1024
        else if (resolutionDropDown.value == 3)
        {
            width = 1280;
            height = 1024;
        }

        //1440 * 900
        else if (resolutionDropDown.value == 4)
        {
            width = 1440;
            height = 900;
        }

        //1280 * 960
        else if (resolutionDropDown.value == 5)
        {
            width = 1280;
            height = 960;
        }

        //1152 * 864
        else if (resolutionDropDown.value == 6)
        {
            width = 1152;
            height = 864;
        }

        //1280 * 720
        else if (resolutionDropDown.value == 7)
        {
            width = 1280;
            height = 720;
        }

        //1024 * 768
        else if (resolutionDropDown.value == 8)
        {
            width = 1024;
            height = 768;
        }

        //更新
        ChangeDisplay();
    }

    /// <summary>
    /// ディスプレイ設定変更
    /// </summary>
    private void ChangeDisplay()
    {
        Screen.SetResolution(width, height, screenModeFlg);
        resolutionDropDown.enabled = !screenModeFlg;
        resolutionText.enabled = !screenModeFlg;
        if (!screenModeFlg && resolutionDropDown.value != 0)
        {
            resolutionDropDown.value = 0;
            ChangeResolution();
        }
    }

    /// <summary>
    /// 言語設定変更
    /// </summary>
    /// <param name="value"></param>
    public void LanguageChange()
    {
        if (languageDropDown.value == 0) JapaneseFlg = true;
        else JapaneseFlg = false;

        LanguageUpdate();
    }

    /// <summary>
    /// 言語更新
    /// </summary>
    private void LanguageUpdate()
    {
        if (JapaneseFlg) languageDropDown.value = 0;
        else languageDropDown.value = 1;
    }

    /// <summary>
    /// X軸感度設定(スライダー用)
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSensitivityX(float value)
    {
        sensitivityX = value;
        SensitivityUpdate();
    }

    /// <summary>
    /// X軸感度設定(インプットフィールド用)
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSensitivityXIF(string value)
    {
        sensitivityX = float.Parse(value);
        SensitivityUpdate();
    }

    /// <summary>
    /// Y軸感度設定(スライダー用)
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSensitivityY(float value)
    {
        sensitivityY = value;
        SensitivityUpdate();
    }

    /// <summary>
    /// Y軸感度設定(インプットフィールド用)
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSensitivityYIF(string value)
    {
        sensitivityY = float.Parse(value);
        SensitivityUpdate();
    }

    /// <summary>
    /// X軸反転
    /// </summary>
    /// <param name="value"></param>
    public void ChangeInversionX(bool value)
    {
        inversionX = value;
        SensitivityUpdate();
    }

    /// <summary>
    /// Y軸反転
    /// </summary>
    /// <param name="value"></param>
    public void ChangeInversionY(bool value)
    {
        inversionY = value;
        SensitivityUpdate();
    }

    /// <summary>
    /// 感度設定更新
    /// </summary>
    private void SensitivityUpdate()
    {
        inputFieldX.text = sensitivityX.ToString("F1");
        sliderX.value = sensitivityX;

        inputFieldY.text = sensitivityY.ToString("F1");
        sliderY.value = sensitivityY;

        toggleX.isOn = inversionX;
        toggleY.isOn = inversionY;
    }


    public void Save()
    {
#if UNITY_EDITOR
        //UnityEditor上なら
        //Assetファイルの中のSaveファイルのパスを入れる
        string path = Application.dataPath + "/Save";

#else
        //そうでなければ
        //.exeがあるところにSaveファイルを作成しそこのパスを入れる
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

        //セーブファイルのパスを設定
        string SaveFilePath = path + "/display.bytes";

        // セーブデータの作成
        DisplaySaveData saveData = CreateSaveData();

        // セーブデータをJSON形式の文字列に変換
        string jsonString = JsonUtility.ToJson(saveData);

        // 文字列をbyte配列に変換
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

        // AES暗号化
        byte[] arrEncrypted = AesEncrypt(bytes);

        // 指定したパスにファイルを作成
        FileStream file = new(SaveFilePath, FileMode.Create, FileAccess.Write);

        //ファイルに保存する
        try
        {
            // ファイルに保存
            file.Write(arrEncrypted, 0, arrEncrypted.Length);
        }
        finally
        {
            // ファイルを閉じる
            if (file != null)
            {
                file.Close();
            }
        }
    }


    public void Load()
    {
#if UNITY_EDITOR
        //UnityEditor上なら
        //Assetファイルの中のSaveファイルのパスを入れる
        string path = Application.dataPath + "/Save";

#else
        //そうでなければ
        //.exeがあるところにSaveファイルを作成しそこのパスを入れる
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

        //セーブファイルのパスを設定
        string SaveFilePath = path + "/display.bytes";

        //セーブファイルがあるか
        if (File.Exists(SaveFilePath))
        {
            //ファイルモードをオープンにする
            FileStream file = new(SaveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // ファイル読み込み
                byte[] arrRead = File.ReadAllBytes(SaveFilePath);

                // 復号化
                byte[] arrDecrypt = AesDecrypt(arrRead);

                // byte配列を文字列に変換
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // JSON形式の文字列をセーブデータのクラスに変換
                DisplaySaveData saveData = JsonUtility.FromJson<DisplaySaveData>(decryptStr);

                //データの反映
                ReadData(saveData);

            }
            finally
            {
                // ファイルを閉じる
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        else
        {
            screenDropDown.value = 0;
            resolutionDropDown.value = 0;
            sensitivityX = 3.0f;
            sensitivityY = 2.0f;
            inversionX = false;
            inversionY = true;
        }

        //更新
        ChangeScreenMode();
        ChangeResolution();
        SensitivityUpdate();
        LanguageUpdate();
    }



    // セーブデータの作成
    private DisplaySaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        DisplaySaveData saveData = new();

        saveData.screenMode = screenDropDown.value;
        saveData.resolution = resolutionDropDown.value;
        saveData.sensitivityX = sensitivityX;
        saveData.sensitivityY = sensitivityY;
        saveData.inversionX = inversionX;
        saveData.inversionY = inversionY;
        saveData.JapaneseFlg = JapaneseFlg;

        return saveData;
    }

    //データの読み込み（反映）
    private void ReadData(DisplaySaveData saveData)
    {
        screenDropDown.value = saveData.screenMode;
        resolutionDropDown.value = saveData.resolution;
        sensitivityX = saveData.sensitivityX;
        sensitivityY = saveData.sensitivityY;
        inversionX = saveData.inversionX;
        inversionY = saveData.inversionY;
        JapaneseFlg = saveData.JapaneseFlg;
    }


    /// <summary>
    ///  AesManagedマネージャーを取得
    /// </summary>
    /// <returns></returns>
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字
        string aesIv = "gi430in3ij0rsa0r";
        string aesKey = "6i5o0283rbh1jgdi";

        AesManaged aes = new();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    /// <summary>
    /// AES暗号化
    /// </summary>
    /// <param name="byteText"></param>
    /// <returns></returns>
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AESマネージャーの取得
        AesManaged aes = GetAesManager();
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

    /// <summary>
    /// AES復号化
    /// </summary>
    /// <param name="byteText"></param>
    /// <returns></returns>
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AESマネージャー取得
        var aes = GetAesManager();
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

    //セーブデータ削除
    public void Init()
    {
#if UNITY_EDITOR
        //UnityEditor上なら
        //Assetファイルの中のSaveファイルのパスを入れる
        string path = Application.dataPath + "/Save";

#else
        //そうでなければ
        //.exeがあるところにSaveファイルを作成しそこのパスを入れる
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

        //ファイル削除
        File.Delete(path + "/display.bytes");

        //リロード
        Load();

        Debug.Log("データの初期化が終わりました");
    }
}

[System.Serializable]
public class DisplaySaveData
{
    public int resolution;
    public int screenMode;
    public float sensitivityX;
    public float sensitivityY;
    public bool inversionX;
    public bool inversionY;
    public bool JapaneseFlg;
}