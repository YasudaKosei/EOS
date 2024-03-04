using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private DataManager dm;

    [SerializeField]
    private TimeManager tm;

    [SerializeField]
    private Text resultTimeText;

    [SerializeField]
    private Image[] starCoinImage;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private Sprite starSprite, noStarSprite;

    [SerializeField]
    private AudioClip audioClip;

    private int stageNum = 0;

    private AudioSource audioSource;

    void Awake()
    {
        //非表示
        resultTimeText.enabled = false;
        for (int i = 0; i < starCoinImage.Length; i++) starCoinImage[i].enabled = false;
        button.SetActive(false);
        audioSource = GetComponent<AudioSource>();


        if (SceneManager.GetActiveScene().name == "Stage01") stageNum = 0;
        else if (SceneManager.GetActiveScene().name == "Stage02") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage03") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Stage04") stageNum = 3;
        else if (SceneManager.GetActiveScene().name == "Stage05") stageNum = 4;
        if (GameData.StageClearTime[stageNum] == 0 || GameData.StageClearTime[stageNum] > tm.ITimer) GameData.StageClearTime[stageNum] = tm.ITimer;

        dm.Save();

        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        yield return new WaitForSeconds(0.5f);

        resultTimeText.text = tm.timeText.text;
        resultTimeText.enabled = true;
        //SE
        audioSource.clip = audioClip;
        audioSource.Play();

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < starCoinImage.Length; i++)
        {
            starCoinImage[i].enabled = true;

            int starFlgsNum = (stageNum * 3) + i;
            if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum))) ==
            (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), (int)Mathf.Pow(2, starFlgsNum)))
            {
                starCoinImage[i].sprite = starSprite;
                //SE
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            else
            {
                starCoinImage[i].sprite = noStarSprite;
                //SE
            }

            yield return new WaitForSeconds(0.5f);
        }

        button.SetActive(true);
        audioSource.clip = audioClip;
        audioSource.Play();

        yield break;
    }

}
