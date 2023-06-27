using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour,ITime
{
    public int Time => _time;

    private int _time;

    void Start()
    {
        _time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _time++;
        }
    }
}
