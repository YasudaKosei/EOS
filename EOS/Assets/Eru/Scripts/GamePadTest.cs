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
            Cursor.lockState = CursorLockMode.Locked;  // �}�E�X�J�[�\�������b�N���Ĕ�\���ɂ���
            Cursor.visible = false;
            

            // Unity��InputSystem���g�p���Ă���ꍇ
            Keyboard.current.onTextInput += (value) => { /* �L�[�{�[�h���͂𖳎����鏈�� */ };
            Debug.Log("true");
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;  // �}�E�X�J�[�\���̃��b�N���������A�\������
            Cursor.visible = true;

            // Unity��InputSystem���g�p���Ă���ꍇ
            Keyboard.current.onTextInput += (value) => { /* �L�[�{�[�h���͂���������R�[�h */ };

            Debug.Log("else");
        }
    }
}
