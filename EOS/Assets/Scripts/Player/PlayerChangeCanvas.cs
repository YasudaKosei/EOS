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
        //有効化
        move.action.Enable();
        change.action.Enable();
        pause.action.Enable();
    }

    void Update()
    {
        //クールタイムカウント
        if (time > 0) time -= Time.deltaTime;

        //選択
        if (time == 0)
        {
            if (move.action.ReadValue<Vector2>().x > 0.0f) Right();
            else if (move.action.ReadValue<Vector2>().x < 0.0f) Left();
        }

    }

    /// <summary>
    /// 右選択
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
    /// 左選択
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
    /// 選択終了処理
    /// </summary>
    public void Fin()
    {
        Stop.stopFlg = false;
        pc.nowStopFlg = false;
        pc.playerID = pc.nowPlayerID;
    }
}
