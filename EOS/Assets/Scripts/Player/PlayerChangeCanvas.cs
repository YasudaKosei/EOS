using System.Collections;
using System.Collections.Generic;
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

    private float coolTime = 0.25f;
    private float time = 0;

    void Start()
    {
        move.action.Enable();
    }

    void Update()
    {
        if (time > 0) time -= Time.deltaTime;

        if (move.action.ReadValue<Vector2>().x > 0.0f) Right();
        else if (move.action.ReadValue<Vector2>().x < 0.0f) Left();
        else time = 0;

        if (change.action.triggered)
        {
            if (pc.nowPlayerID != pc.playerID) pc.ChangePlayer();
            gameObject.SetActive(false);
            Stop.stopFlg = false;
            pc.nowStopFlg = false;
        }
    }

    public void Right()
    {
        if (pc.playerID == 4 || time > 0) return;
        pc.playerID++;
        time = coolTime;
    }

    public void Left()
    {
        if (pc.playerID == 0 || time > 0) return;
        pc.playerID--;
        time = coolTime;
    }
}
