using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{

    public float speed = 0.2f;
    public float delay = 2.0f;

    void Start()
    {
        Invoke("Swith2", 0f);
    }

    void Update()
    {
        Vector3 p = new Vector3(speed, 0, 0);
        transform.Translate(p);
    }
    void Swith()
    {
        speed = 0.1f;
        Invoke("Swith2", delay);
    }
    void Swith2()
    {
        speed = -0.1f;
        Invoke("Swith", delay);
    }
}
