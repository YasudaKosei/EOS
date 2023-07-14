using UnityEngine;
using UnityEngine.InputSystem;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private GameObject can;

    [SerializeField] 
    private RebindSaveManager rsm;

    private void Awake()
    {
        rsm.Load();
        can.SetActive(false);
        pause.action.Enable();
    }

    void Update()
    {
        if(pause.action.triggered) can.SetActive(!can.activeSelf);
    }
}
