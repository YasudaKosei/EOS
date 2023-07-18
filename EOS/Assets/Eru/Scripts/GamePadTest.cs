using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePadTest : MonoBehaviour
{
    [SerializeField]
    private InputActionReference move;

    // Start is called before the first frame update
    void Start()
    {
        move.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(move.action.ReadValue<Vector2>());
    }
}
