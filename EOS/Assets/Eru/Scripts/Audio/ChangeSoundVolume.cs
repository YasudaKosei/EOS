using UnityEngine;
using UnityEngine.Audio;

public class ChangeSoundVolume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BgmVolume", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SeVolume", volume);
    }

    public void SetMASTER(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
