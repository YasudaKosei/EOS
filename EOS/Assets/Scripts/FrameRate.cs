using UnityEngine;

public class FrameRate : MonoBehaviour
{
    private int targetFps = 60;

    void Awake()
    {
        Application.targetFrameRate = targetFps;
    }
}