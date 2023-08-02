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

    public Text timetext;

    void Start()
    {
        //有効化
        move.action.Enable();
        change.action.Enable();
        pause.action.Enable();
        cL.action.Enable();
        cR.action.Enable();
    }

    void Update()
    {
        if (Stop.stopFlg) return;

        //クールタイムカウント
        if (time > 0)
        {
            time -= Time.deltaTime;
            timetext.text = Mathf.Ceil(time).ToString();
        }
        else
        {
            timetext.text = "OK";
            if (pc.elevatorFlg == true) return;
            if (Input.GetKeyDown(KeyCode.F)) CP();
        }

        if(pc.elevatorFlg == false)
        {
            if (cR.action.triggered) Right();
            else if (cL.action.triggered) Left();
            else if (Input.GetKeyDown(KeyCode.Alpha1)) num(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) num(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) num(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4)) num(3);
            else if (Input.GetKeyDown(KeyCode.Alpha5)) num(4);
        }
        
    }

    /// <summary>
    /// 右選択
    /// </summary>
    public void Right()
    {
        if (pc.playerID == 4 || time > 0) return;
        pc.playerID++;
    }

    /// <summary>
    /// 左選択
    /// </summary>
    public void Left()
    {
        if (pc.playerID == 0 || time > 0) return;
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
