using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SEManager : MonoBehaviour
{
    public static SEManager instance; // シングルトンインスタンス

    [System.Serializable]
    public class SoundClip
    {
        public string name;          // 効果音の名前
        public AudioClip clip;      // AudioClipへの参照
    }

    public SoundClip[] soundClips;  // 配列で各効果音を格納

    public SoundClip startClips;  // スタート効果音を格納

    private AudioSource audioSource;

    private void Awake()
    {
        // シングルトンパターンを実装
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 効果音を再生する関数
    public void PlaySE(string soundName)
    {
        // soundClipsから指定された名前の効果音を検索
        SoundClip soundClip = System.Array.Find(soundClips, s => s.name == soundName);

        if (soundClip == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }

        audioSource.PlayOneShot(soundClip.clip);
    }

    public void StartSE()
    {
        audioSource.PlayOneShot(startClips.clip);
    }

    public void StartENDSE()
    {
        audioSource.Stop();
    }
}
