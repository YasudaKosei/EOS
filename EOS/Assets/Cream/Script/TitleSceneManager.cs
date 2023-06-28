using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void RankingScene()
    {
        SceneManager.LoadScene("Ranking");
    }
}
