//データをファイルに保存します

using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Save : MonoBehaviour
{
    void OnEnable()
    {
        DoSave();
    }

    private void DoSave()
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
        string SaveFilePath = path + "/save.bytes";

        // セーブデータの作成
        SaveData saveData = CreateSaveData();

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