using UnityEngine;
using Cinemachine;

public class SensitivityManager : MonoBehaviour
{
    private CinemachineFreeLook freeLook;

    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        freeLook.m_XAxis.m_MaxSpeed = DisplayManager.sensitivityX * 100;
        freeLook.m_YAxis.m_MaxSpeed = DisplayManager.sensitivityY;
        freeLook.m_XAxis.m_InvertInput = DisplayManager.inversionX;
        freeLook.m_YAxis.m_InvertInput = DisplayManager.inversionY;
    }
}
