using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
    //現在のゲームのバージョンを取得するスクリプトです

    [SerializeField]
    private Text vText;

    void Start()
    {
        vText.text = "Version " + Application.version;
        Debug.Log("Game Version: " + vText.text);
    }
}

