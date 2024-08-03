using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsSelect : MonoBehaviour
{
    private Text text;
    public string jpText;
    public string enText;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        string lang = nn.oe.Language.GetDesired();

        if (lang == "ja")
        {
            text.text = jpText;
        }
        else
        {
            text.text = enText;
        }
    }
}
