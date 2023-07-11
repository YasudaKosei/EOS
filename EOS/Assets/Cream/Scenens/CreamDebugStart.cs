using UnityEngine;
using UnityEngine.SceneManagement;

public class CreamDebugStart : MonoBehaviour
{
    [SerializeField] Fade fade;
    
    public void MoveTitleScene()
    {
        Load.SL = 1;
        fade.FadeIn(1f, () => SceneManager.LoadScene("LoadScene"));
    }

    public void MoveRankingScene()
    {
        Load.SL = 2;
        fade.FadeIn(1f, () => SceneManager.LoadScene("LoadScene"));
    }

    public void MoveGameScene()
    {
        Load.SL = 3;
        fade.FadeIn(1f, () => SceneManager.LoadScene("LoadScene"));
    }

}
