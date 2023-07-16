using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null)
        {
            Cursor.lockState = CursorLockMode.Locked;  // マウスカーソルをロックして非表示にする
            Cursor.visible = false;
            

            // UnityのInputSystemを使用している場合
            Keyboard.current.onTextInput += (value) => { /* キーボード入力を無視する処理 */ };
            Debug.Log("true");
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;  // マウスカーソルのロックを解除し、表示する
            Cursor.visible = true;

            // UnityのInputSystemを使用している場合
            Keyboard.current.onTextInput += (value) => { /* キーボード入力を処理するコード */ };

            Debug.Log("else");
        }
    }
}
