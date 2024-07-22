using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private int targetFps = 60;

    void Awake()
    {
        Application.targetFrameRate = targetFps;
        Stop.stopFlg = false;
    }
}