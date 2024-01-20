using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    [SerializeField]
    private int targetFps = 60;

    void Awake()
    {
        Application.targetFrameRate = targetFps;
    }
}