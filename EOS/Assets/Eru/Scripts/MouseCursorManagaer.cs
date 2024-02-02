using UnityEngine;

public class MouseCursorManagaer : MonoBehaviour
{
    void Update()
    {
        if (!Stop.stopFlg)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
