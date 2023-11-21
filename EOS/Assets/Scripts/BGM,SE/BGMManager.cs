using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMManager : MonoBehaviour
{
    // BGMを制御するスクリプト

    // シーン移行後も使いたいのでシングルトンにする
    public static BGMManager instance;
    [System.Serializable]

    //BGMのクリップ
    public class BGMClip
    {
        public string name;        // BGMの名前
        public AudioClip clip;     // AudioClipへの参照
    }

    public BGMClip[] bgmClips;

    //BGMを適用させるオーディオソース
    private AudioSource audioSource;

    private void Awake()
    {
        // シングルトン
        if (instance == null)
        {
            instance = this;
            // シーンをまたいでオブジェクトを保持
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    // BGMを再生する関数
    public void PlayBGM(string bgmName)
    {
        // bgmClipsから指定された名前のBGMを検索
        BGMClip bgmClip = System.Array.Find(bgmClips, i => i.name == bgmName);

        if (bgmClip == null)
        {
            Debug.LogWarning("BGM: " + bgmName + " not found!");
            return;
        }

        // 現在再生中のBGMと同じBGMが要求されている場合は何もしない
        if (audioSource.clip == bgmClip.clip && audioSource.isPlaying)
        {
            return;
        }

        // 現在再生中のBGMがある場合、それを停止
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // 新しいBGMを設定し、再生
        audioSource.clip = bgmClip.clip;
        audioSource.Play();
    }


    // BGMを停止する関数
    public void StopBGM()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // BGMの音量を設定する関数
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
