using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugStart : MonoBehaviour
{
    //
    [SerializeField] Fade fade;
    
    public void MoveTitleScene()
    {
        Load.SL = 1;
        fade.FadeIn(0.5f, () => SceneManager.LoadScene("LoadScene"));
    }

    public void MoveStageSelectScene()
    {
        Load.SL = 2;
        fade.FadeIn(0.5f, () => SceneManager.LoadScene("LoadScene"));
    }

    public void MoveStage01Scene()
    {
        Load.SL = 3;
        fade.FadeIn(0.5f, () => SceneManager.LoadScene("LoadScene"));
    }

}
