using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private PC pc;

    private void Awake()
    {
        this.gameObject.SetActive(GameData.easyModeFlg);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("チェックポイント通過");
            pc.startPos = this.transform;
        }
    }
}
