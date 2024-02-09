using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string sceneBGM;

    // Start is called before the first frame update
    void Start()
    {
        if(sceneBGM != null) BGMManager.instance.PlayBGM(sceneBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
