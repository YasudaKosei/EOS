//データをファイルに保存します

using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Save : MonoBehaviour
{
    FsSaveDataPlayerPrefs fsSaveDataPlayerPrefs;

    void OnEnable()
    {
        fsSaveDataPlayerPrefs = GameObject.FindWithTag("SaveData").GetComponent<FsSaveDataPlayerPrefs>();
        DoSave();
    }

    private void DoSave()
    {
        // セーブデータの作成
        SaveData saveData = CreateSaveData();

        // セーブデータをJSON形式の文字列に変換
        string jsonString = JsonUtility.ToJson(saveData);

        PlayerPrefs.SetString("Save", jsonString);

        fsSaveDataPlayerPrefs.SavePlayerPrefs();

        this.enabled = false;//このスクリプトをオフにする
    }

    // セーブデータの作成
    private SaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        SaveData saveData = new();

        //ゲームデータの値をセーブデータに代入
        for (int i = 0; i < 5; i++)
        {
            saveData.StageStarCount[i] = GameData.StageStarCount[i];

            saveData.StageClearTime[i] = GameData.StageClearTime[i];
        }
        saveData.stageStar = GameData.stageStar;

        saveData.easyModeFlg = GameData.easyModeFlg;

        saveData.tutorialFlg = GameData.tutorialFlg;

        saveData.distance = GameData.distance;

        return saveData;
    }

    /// AesManagedマネージャーを取得
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字(Read.csと同じやつに)
        string aesIv = "d87fgw8uq43n08fr";
        string aesKey = "54nuiug23tf8y34r";

        AesManaged aes = new()
        {
            KeySize = 128,
            BlockSize = 128,
            Mode = CipherMode.CBC,
            IV = Encoding.UTF8.GetBytes(aesIv),
            Key = Encoding.UTF8.GetBytes(aesKey),
            Padding = PaddingMode.PKCS7
        };
        return aes;
    }

    /// AES暗号化
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AESマネージャーの取得
        AesManaged aes = GetAesManager();
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

}