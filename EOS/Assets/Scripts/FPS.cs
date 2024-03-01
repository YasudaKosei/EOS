using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField]
    private int fps = 60;

    void Awake()
    {
        Application.targetFrameRate = fps;
    }
}
