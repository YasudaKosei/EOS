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
    private PlayerInput pi;

    void Start()
    {
        
    }

    void Update()
    {
        //if (move.action.ReadValue<Vector2>() == new Vector2(1.0f, move.action.ReadValue<Vector2>().y)) Debug.Log("��");
        //else if (move.action.ReadValue<Vector2>() == new Vector2(-1.0f, move.action.ReadValue<Vector2>().y)) Debug.Log("��");
        Debug.Log(move.action.bindings[1]);
        //if((move.action.bindings[1] == )
    }
}
