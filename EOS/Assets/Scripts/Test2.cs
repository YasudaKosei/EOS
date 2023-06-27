using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public GameObject test;

    void Start()
    {
        
    }

    void Update()
    {
        if(test != null) Debug.Log(test.GetComponent<ITime>().ITime);
    }
}
