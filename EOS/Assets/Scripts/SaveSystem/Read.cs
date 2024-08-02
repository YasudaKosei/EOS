//ファイルのデータを読み込みます

using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Read : MonoBehaviour
{
    void OnEnable()
    {
        DoRead();
    }

    private void DoRead()
    {
        string decryptStr = PlayerPrefs.GetString("Save", "");

        // JSON形式の文字列をセーブデータのクラスに変換
        SaveData saveData = JsonUtility.FromJson<SaveData>(decryptStr);

        //データの反映
        ReadData(saveData);

        this.enabled = false;

    }

    //データの読み込み（反映）
    private void ReadData(SaveData saveData)
    {
        for (int i = 0; i < 5; i++) {
            GameData.StageStarCount[i] = saveData.StageStarCount[i];

            GameData.StageClearTime[i] = saveData.StageClearTime[i];
        }
        GameData.stageStar = saveData.stageStar;

        GameData.easyModeFlg = saveData.easyModeFlg;

        GameData.tutorialFlg = saveData.tutorialFlg;

        GameData.distance = saveData.distance;
    }

    /// AesManagedマネージャーを取得
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字(Save.csと同じやつに)
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

    /// AES復号化
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AESマネージャー取得
        var aes = GetAesManager();
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

}