using UnityEngine;
using UnityEngine.SceneManagement;
public class StarCoin : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private int starNum;

    private int starFlgsNum = 0, stageNum = 0;

    private bool getFlg = false;

    public GameObject coinAudioObject;

    [SerializeField]
    private Material translucent;

    [SerializeField]
    private GameObject effect;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage01") stageNum = 0;
        else if (SceneManager.GetActiveScene().name == "Stage02") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage03") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Stage04") stageNum = 3;
        else if (SceneManager.GetActiveScene().name == "Stage05") stageNum = 4;
        starFlgsNum = (stageNum * 3) + starNum;
        if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum))) ==
            (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum)))
        {
            getFlg = true;

            GetComponent<MeshRenderer>().material = translucent;
            effect.SetActive(false);
        }
        else getFlg = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("コインゲット");

            //コイン獲得の効果音
            GameObject obj =  Instantiate(coinAudioObject);
            Destroy(obj, 3.0f);

            //未獲得だったら
            if (!getFlg)
            {
                GameData.stageStar |= (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum));
                GameData.StageStarCount[stageNum]++;
            }

            Destroy(gameObject);
        }
    }
}
