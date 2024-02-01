using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private DataManager dm;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text resultTimeText;

    [SerializeField]
    private Image[] starCoinImage;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private Sprite starSprite, noStarSprite;

    void Awake()
    {
        //非表示
        resultTimeText.enabled = false;
        for (int i = 0; i < starCoinImage.Length; i++) starCoinImage[i].enabled = false;
        button.SetActive(false);
        dm.Save();

        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        yield return new WaitForSeconds(0.5f);

        resultTimeText.text = timeText.text;
        resultTimeText.enabled = true;
        //SE

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < starCoinImage.Length; i++)
        {
            starCoinImage[i].enabled = true;
            if ((GameData.stageStar & (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), i)) ==
            (StageStarManager.StageStar)StageStarManager.StageStar.ToObject(typeof(StageStarManager.StageStar), i))
            {
                starCoinImage[i].sprite = starSprite;
                //SE
            }
            else
            {
                starCoinImage[i].sprite = noStarSprite;
                //SE
            }

            yield return new WaitForSeconds(0.5f);
        }

        button.SetActive(true);

        yield break;
    }
}
