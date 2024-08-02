using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public class ChangeSoundVolume : MonoBehaviour
{
    [SerializeField,Header("ミキサー")]
    private AudioMixer audioMixer;

    [SerializeField, Header("MASTERボリュームスライダー")]
    private Slider masterSlider;

    [SerializeField, Header("BGMボリュームスライダー")]
    private Slider bgmSlider;

    [SerializeField, Header("SEボリュームスライダー")]
    private Slider seSlider;

    [SerializeField, Header("MASTERミュートトグル")]
    private Toggle masterToggle;

    [SerializeField, Header("BGMミュートトグル")]
    private Toggle bgmToggle;

    [SerializeField, Header("SEミュートトグル")]
    private Toggle seToggle;

    FsSaveDataPlayerPrefs fsSaveDataPlayerPrefs;

    private void Awake()
    {
        fsSaveDataPlayerPrefs = GameObject.FindWithTag("SaveData").GetComponent<FsSaveDataPlayerPrefs>();
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }

    public void SetBGM(float volume)
    {
        if (volume <= -50f)
        {
            volume = -80f;
            bgmToggle.isOn = false;
        }
        else bgmToggle.isOn = true;
        audioMixer.SetFloat("BgmVolume", volume);
        Save();
    }

    public void SetSE(float volume)
    {
        if (volume <= -50f)
        {
            volume = -80f;
            seToggle.isOn = false;
        }
        else seToggle.isOn = true;
        audioMixer.SetFloat("SeVolume", volume);
        Save();
    }

    public void SetMASTER(float volume)
    {
        if (volume <= -50f)
        {
            volume = -80f;
            masterToggle.isOn = false;
        }
        else masterToggle.isOn = true;
        audioMixer.SetFloat("MasterVolume", volume);
        Save();
    }

    public void MuteMASTER(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = masterSlider.value;

        audioMixer.SetFloat("MasterVolume", vol);
        Save();
    }

    public void MuteBGM(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = bgmSlider.value;

        audioMixer.SetFloat("BgmVolume", vol);
        Save();
    }

    public void MuteSE(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = seSlider.value;

        audioMixer.SetFloat("SeVolume", vol);
        Save();
    }


    /// <summary>
    /// セーブ
    /// </summary>
    public void Save()
    {
        // セーブデータの作成
        AudioSaveData saveData = CreateSaveData();

        // セーブデータをJSON形式の文字列に変換
        string jsonString = JsonUtility.ToJson(saveData);

        PlayerPrefs.SetString("ChangeSoundVolume", jsonString);

        fsSaveDataPlayerPrefs.SavePlayerPrefs();
    }

    public void Load()
    {
        string decryptStr = PlayerPrefs.GetString("ChangeSoundVolume", "");

        if (decryptStr == "")
        {
            masterSlider.value = -20f;
            bgmSlider.value = -20f;
            seSlider.value = -20f;
            masterToggle.isOn = true;
            bgmToggle.isOn = true;
            seToggle.isOn = true;
            audioMixer.SetFloat("MasterVolume", masterSlider.value);
            audioMixer.SetFloat("BgmVolume", bgmSlider.value);
            audioMixer.SetFloat("SeVolume", seSlider.value);
            Save();
        }
        else
        {
            // JSON形式の文字列をセーブデータのクラスに変換
            AudioSaveData saveData = JsonUtility.FromJson<AudioSaveData>(decryptStr);

            //データの反映
            ReadData(saveData);
        }
    }


    /// <summary>
    /// セーブデータの作成
    /// </summary>
    /// <returns></returns>
    private AudioSaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        AudioSaveData saveData = new()
        {
            //ゲームデータの値をセーブデータに代入
            //Master
            masVol = masterSlider.value,
            masFlg = masterToggle.isOn,

            //Bgm
            bgmVol = bgmSlider.value,
            bgmFlg = bgmToggle.isOn,

            //Se
            seVol = seSlider.value,
            seFlg = seToggle.isOn
        };

        return saveData;
    }

    /// <summary>
    /// データの読み込み（反映）
    /// </summary>
    /// <param name="saveData"></param>
    private void ReadData(AudioSaveData saveData)
    {
        //Master
        masterToggle.isOn = saveData.masFlg;
        masterSlider.value = saveData.masVol;
        audioMixer.SetFloat("MasterVolume", saveData.masVol);

        //Bgm
        bgmToggle.isOn = saveData.bgmFlg;
        bgmSlider.value = saveData.bgmVol;
        audioMixer.SetFloat("BgmVolume", saveData.bgmVol);

        //Se
        seToggle.isOn = saveData.seFlg;
        seSlider.value = saveData.seVol;
        audioMixer.SetFloat("SeVolume", saveData.seVol);
    }



    /// <summary>
    ///  AesManagedマネージャーを取得
    /// </summary>
    /// <returns></returns>
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字(Read.csと同じやつに)
        string aesIv = "ndfiu89f329ifgh7";
        string aesKey = "otg3mene43ui238o";

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

    /// <summary>
    /// セーブデータ削除
    /// </summary>
    public void Init()
    {

    }
}

[System.Serializable]
public class AudioSaveData
{
    public float masVol;
    public float bgmVol;
    public float seVol;
    public bool masFlg;
    public bool bgmFlg;
    public bool seFlg;
}
