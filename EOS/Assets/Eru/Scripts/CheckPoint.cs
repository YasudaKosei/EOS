using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private PC pc;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        this.gameObject.SetActive(GameData.easyModeFlg);
        audioSource.clip = audioClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && pc.startPos != this.transform)
        {
            Debug.Log("チェックポイント通過");
            pc.startPos = this.transform;
            audioSource.Play();
        }
    }
}
