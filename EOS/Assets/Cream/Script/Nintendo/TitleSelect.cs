using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSelect : MonoBehaviour
{
    public GameObject jp;
    public GameObject en;

    // Start is called before the first frame update
    void Start()
    {
        string lang = nn.oe.Language.GetDesired();

        if (lang == "ja")
        {
            jp.SetActive(true);
        }
        else
        {
            en.SetActive(true);
        }
    }
}
