using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private PC pc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("チェックポイント通過");
            pc.startPos = this.transform;
        }
    }
}
