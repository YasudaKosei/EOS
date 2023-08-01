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

    private float time = 0;

    public Text timetext;

    void Start()
    {
        //�L����
        move.action.Enable();
        change.action.Enable();
        pause.action.Enable();
    }

    void Update()
    {
        //�N�[���^�C���J�E���g
        if (time > 0)
        {
            time -= Time.deltaTime;
            timetext.text = Mathf.Ceil(time).ToString();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E)) Right();
            else if (Input.GetKeyDown(KeyCode.Q)) Left();
            else if (Input.GetKeyDown(KeyCode.Alpha1)) num(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) num(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) num(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4)) num(3);
            else if (Input.GetKeyDown(KeyCode.Alpha5)) num(4);
            timetext.text = "OK";
        }
    }

    /// <summary>
    /// �E�I��
    /// </summary>
    public void Right()
    {
        if (pc.playerID == 4 || time > 0) return;
        pc.playerID++;
        pc.ChangePlayer();
        Fin();
    }

    /// <summary>
    /// ���I��
    /// </summary>
    public void Left()
    {
        if (pc.playerID == 0 || time > 0) return;
        pc.playerID--;
        pc.ChangePlayer();
        Fin();
    }

    /// <summary>
    /// �����I��
    /// </summary>
    public void num(int num)
    {
        pc.playerID = num;
        pc.ChangePlayer();
        Fin();
    }

    /// <summary>
    /// �I���I������
    /// </summary>
    public void Fin()
    {
        Stop.stopFlg = false;
        pc.nowStopFlg = false;
        pc.playerID = pc.nowPlayerID;

        time = pc.coolDownTime;
    }
}
