using UnityEngine;
using UnityEngine.SceneManagement;
public class StarCoin : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private int starNum;

    private int starFlgsNum = 0, stageNum = 0;

    private bool getFlg = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage01") stageNum = 0;
        else if (SceneManager.GetActiveScene().name == "Stage02") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage03") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Stage04") stageNum = 3;
        else if (SceneManager.GetActiveScene().name == "Stage05") stageNum = 4;
        starFlgsNum = (stageNum * 3) + starNum;

        if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), starFlgsNum)) ==
            (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), starFlgsNum))
        {
            getFlg = true;
            //半透明にする

        }
        else getFlg = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("コインゲット");

            //未獲得だったら
            if (!getFlg)
            {
                GameData.stageStar |= (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), starFlgsNum);
                GameData.StageStarCount[stageNum]++;
            }

            Destroy(gameObject);
        }
    }
}
