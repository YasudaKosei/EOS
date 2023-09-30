using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerChange pc;

    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private InputActionReference change;

    [SerializeField]
    private InputActionReference pause;

    private float coolTime = 0.25f;
    private float time = 0;

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
        if (time > 0) time -= Time.deltaTime;

        //�I��
        if (time == 0)
        {
            if (move.action.ReadValue<Vector2>().x > 0.0f) Right();
            else if (move.action.ReadValue<Vector2>().x < 0.0f) Left();
        }

    }

    /// <summary>
    /// �E�I��
    /// </summary>
    public void Right()
    {
        if (pc.playerID == 4 || time > 0) return;
        pc.playerID++;
        time = coolTime;
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
        time = coolTime;
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
    }
}
