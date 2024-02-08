using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class DebugS : MonoBehaviour
{
    private CinemachineFreeLook freeLook;

    [SerializeField]
    private InputActionReference input;

    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
        Debug.Log(freeLook.m_XAxis.m_MaxSpeed);
        Debug.Log(freeLook.m_YAxis.m_MaxSpeed);
        Debug.Log(freeLook.m_XAxis.m_InvertInput);
        Debug.Log(freeLook.m_YAxis.m_InvertInput);
    }

    void Update()
    {
        
    }
}
