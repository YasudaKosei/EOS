using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int targetFps = 60;

    private void Awake()
    {
        Application.targetFrameRate = targetFps;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
