using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugStart : MonoBehaviour
{
    [SerializeField] Fade fade;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Load.SL = 1;
            fade.FadeIn(1f, () => SceneManager.LoadScene("LoadScene"));
        }
    }
}
