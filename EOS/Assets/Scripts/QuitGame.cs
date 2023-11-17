using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //ゲームを終了する為のスクリプトです

    public void ExitGame()
    {
        // ゲームを終了する
        Application.Quit();

        // Unityエディタで実行している場合はエディタを停止
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
