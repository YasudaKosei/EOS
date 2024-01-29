using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CleamGoalManager : MonoBehaviour
{
    [SerializeField] GameObject Result;

    [SerializeField] Text ResultTime;

    [SerializeField] Text TimeText;

    DebugStart debugStart;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("CLEAR");
            Stop.stopFlg = true;
            ResultTime.text = TimeText.text;
            BGMManager.instance.StopBGM();
            Result.SetActive(true);
            Invoke("MoveTitle", 5f);
        }
    }

    void MoveTitle()
    {
        debugStart = FindObjectOfType<DebugStart>();
        debugStart.MoveTitleScene();
    }

}
