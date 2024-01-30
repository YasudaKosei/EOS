using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private int targetFps = 60;

    private CinemachineBrain cb;

    void Awake()
    {
        Application.targetFrameRate = targetFps;
        cb = GetComponent<CinemachineBrain>();
    }

    private void Update()
    {
        cb.enabled = !Stop.stopFlg;
    }
}