using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectManager : MonoBehaviour
{
    [SerializeField]
    private Fade fade;

    private void Start()
    {
        Debug.Log("移動しました");
    }

    public void SceneLoad(int value)
    {
        Load.SL = value;
        fade.FadeIn(0.5f, () => SceneManager.LoadScene("LoadScene"));
    }

    public void RetryLoad()
    {
        fade.FadeIn(0.5f, () => SceneManager.LoadScene("LoadScene"));
    }
}
