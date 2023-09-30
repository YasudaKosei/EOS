using UnityEngine;
using UnityEngine.InputSystem;

public class OptionManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private GameObject select,DisCan,keyCan,padCan,VolCan,OthCan;

    [SerializeField] 
    private RebindSaveManager rsm;

    private bool nowFlg = false;

    private void Awake()
    {
        rsm.Load();
        select.SetActive(false);
        keyCan.SetActive(false);
        padCan.SetActive(false);
        DisCan.SetActive(false);
        VolCan.SetActive(false);
        OthCan.SetActive(false);
        pause.action.Enable();
        nowFlg = false;
    }

    void Update()
    {
        if (pause.action.triggered)
        {
            if (Stop.stopFlg == false)
            {
                Set();
            }
            else if(nowFlg)
            {
                End();
            }
        }
    }

    public void Set()
    {
        select.SetActive(true);
        DisCan.SetActive(true);
        Stop.stopFlg = true;
        nowFlg = true;
    }

    public void End()
    {
        select.SetActive(false);
        keyCan.SetActive(false);
        padCan.SetActive(false);
        DisCan.SetActive(false);
        VolCan.SetActive(false);
        OthCan.SetActive(false);
        Stop.stopFlg = false;
        nowFlg = false;
    }
    public void DisplayCanvas()
    {
        DisCan.SetActive(true);
        keyCan.SetActive(false);
        padCan.SetActive(false);
        VolCan.SetActive(false);
        OthCan.SetActive(false);
    }
    public void KeyBoardCanvas()
    {
        keyCan.SetActive(true);
        padCan.SetActive(false);
        DisCan.SetActive(false);
        VolCan.SetActive(false);
        OthCan.SetActive(false);
    }

    public void GamePadCanvas()
    {
        padCan.SetActive(true);
        keyCan.SetActive(false);
        DisCan.SetActive(false);
        VolCan.SetActive(false);
        OthCan.SetActive(false);
    }

    public void VolumeCanvas()
    {
        VolCan.SetActive(true);
        keyCan.SetActive(false);
        padCan.SetActive(false);
        DisCan.SetActive(false);
        OthCan.SetActive(false);
    }

    public void OthersCanvas()
    {
        OthCan.SetActive(true);
        VolCan.SetActive(false);
        keyCan.SetActive(false);
        padCan.SetActive(false);
        DisCan.SetActive(false);
    }
}
