using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField]
    AudioSource seAudioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            seAudioSource.Play();
        }
    }
}