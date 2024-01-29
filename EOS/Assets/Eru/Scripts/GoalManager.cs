using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultUI;

    private void Awake()
    {
        //リザルトUI非表示
        resultUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("Goal");

        //停止処理
        Stop.stopFlg = true;
        BGMManager.instance.StopBGM();

        //リザルトUI表示
        resultUI.SetActive(true);
    }
}
