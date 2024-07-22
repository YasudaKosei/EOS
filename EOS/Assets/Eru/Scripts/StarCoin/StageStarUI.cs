using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageStarUI : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int stageNum = 1;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage01") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage02") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Stage03") stageNum = 3;
        else if (SceneManager.GetActiveScene().name == "Stage04") stageNum = 4;
        else if (SceneManager.GetActiveScene().name == "Stage05") stageNum = 5;
    }

    void Update()
    {
        text.text = $"{stageNum} - {GameData.StageStarCount[stageNum - 1]}";
    }
}
