using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarCanvas : MonoBehaviour
{
    [SerializeField]
    private Image[] starImg;

    [SerializeField]
    private Sprite starSpr,noStarSpr;

    private int starFlgsNum = 0, stageNum = 0;

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Stage01") stageNum = 0;
        else if (SceneManager.GetActiveScene().name == "Stage02") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage03") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Stage04") stageNum = 3;
        else if (SceneManager.GetActiveScene().name == "Stage05") stageNum = 4;
        starFlgsNum = (stageNum * 3);
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum + i))) ==
                (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum + i))) starImg[i].sprite = starSpr;
            else starImg[i].sprite = noStarSpr;
        }
    }
}
