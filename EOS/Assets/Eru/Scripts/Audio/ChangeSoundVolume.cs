using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ChangeSoundVolume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Slider bgmSlider;

    [SerializeField]
    private Slider seSlider;

    [SerializeField]
    private Toggle masterToggle;

    [SerializeField]
    private Toggle bgmToggle;

    [SerializeField]
    private Toggle seToggle;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BgmVolume"))
        {
            BgmLodeVolume();
        }
        else
        {
            SetBGM();
        }
        if (PlayerPrefs.HasKey("SeVolume"))
        {
            SeLodeVolume();
        }
        else
        {
            SetSE();
        }
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            MasterLodeVolume();
        }
        else
        {
            SetMASTER();
        }
    }

    public void SetBGM()
    {
        float volume = bgmSlider.value;

        if (volume <= -50f)
        {
            volume = -80f;
            bgmToggle.isOn = false;
        }
        audioMixer.SetFloat("BgmVolume", volume);

        PlayerPrefs.SetFloat("BgmVolume", volume);
    }

    public void SetSE()
    {
        float volume = seSlider.value;

        if (volume <= -50f)
        {
            volume = -80f;
            seToggle.isOn = false;
        }
        audioMixer.SetFloat("SeVolume", volume);

        PlayerPrefs.SetFloat("SeVolume", volume);
    }

    public void SetMASTER()
    {
        float volume = masterSlider.value;

        if (volume <= -50f)
        {
            volume = -80f;
            masterToggle.isOn = false;
        }
        audioMixer.SetFloat("MasterVolume", volume);

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void MuteMASTER(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = masterSlider.value;

        audioMixer.SetFloat("MasterVolume", vol);

        PlayerPrefs.SetFloat("MasterVolume", vol);
    }

    public void MuteBGM(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = bgmSlider.value;

        audioMixer.SetFloat("BgmVolume", vol);

        PlayerPrefs.SetFloat("BgmVolume", vol);
    }

    public void MuteSE(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = seSlider.value;

        audioMixer.SetFloat("SeVolume", vol);

        PlayerPrefs.SetFloat("SeVolume", vol);
    }

    private void MasterLodeVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        SetMASTER();
    }
    private void BgmLodeVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BgmVolume");
        SetBGM();
    }

    private void SeLodeVolume()
    {
        seSlider.value = PlayerPrefs.GetFloat("SeVolume");
        SetSE();
    }
}
