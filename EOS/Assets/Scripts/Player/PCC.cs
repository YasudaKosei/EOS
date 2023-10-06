using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PCC : MonoBehaviour
{

    [SerializeField]
    private PC pc;

    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private InputActionReference change;

    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private InputActionReference cL;

    [SerializeField]
    private InputActionReference cR;

    private float time = 0;

    [SerializeField]
    private bool tChangeFlg = false;
    [SerializeField]
    private bool pChangeFlg = false;

    public Image[] timeGage;

    void Start()
    {
        //有効化
        move.action.Enable();
        change.action.Enable();
        pause.action.Enable();
        cL.action.Enable();
        cR.action.Enable();


        tChangeFlg = true;
        pChangeFlg = true;
    }

    void Update()
    {
        if (Stop.stopFlg) return;

        if (pc.elevatorFlg)
        {
            for (int i = 0; i < timeGage.Length; i++)
            {
                timeGage[i].fillAmount = 1;
            }
        }
        else
        {
            for (int i = 0; i < timeGage.Length; i++)
            {
                timeGage[i].fillAmount = time / pc.coolDownTime;
            }
        }

        //クールタイムカウント
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (tChangeFlg && pChangeFlg && !pc.elevatorFlg) if (Input.GetKeyDown(KeyCode.F)) CP();
        }

        if (pc.nowPlayer.TryGetComponent<CarrotController>(out CarrotController tomatoC))
        {
            if (tomatoC.isJumping)
            {
                for (int i = 0; i < timeGage.Length; i++)
                {
                    timeGage[i].fillAmount = 1;
                }
                tChangeFlg = false;
            }
            else tChangeFlg = true;
        }

        if (pc.nowPlayer.TryGetComponent<PotController>(out PotController potC))
        {
            if (potC.isJumping)
            {
                for (int i = 0; i < timeGage.Length; i++)
                {
                    timeGage[i].fillAmount = 1;
                }
                pChangeFlg = false;
            }
            else pChangeFlg = true;
        }

        if (cR.action.triggered) Right();
        else if (cL.action.triggered) Left();
        else if (Input.GetKeyDown(KeyCode.Alpha1)) num(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) num(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) num(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) num(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5)) num(4);
        
    }

    /// <summary>
    /// 右選択
    /// </summary>
    public void Right()
    {
        if (pc.playerID == 4) return;
        pc.playerID++;
    }

    /// <summary>
    /// 左選択
    /// </summary>
    public void Left()
    {
        if (pc.playerID == 0) return;
        pc.playerID--;
    }

    /// <summary>
    /// 数字選択
    /// </summary>
    public void num(int num)
    {
        pc.playerID = num;
    }

    public void CP()
    {
        if (pc.nowPlayerID == pc.playerID) return;
        pc.ChangePlayer();
        Fin();
    }

    /// <summary>
    /// 選択終了処理
    /// </summary>
    public void Fin()
    {
        Stop.stopFlg = false;
        pc.nowStopFlg = false;
        pc.playerID = pc.nowPlayerID;

        time = pc.coolDownTime;
    }
}
