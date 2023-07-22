using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteObj : MonoBehaviour
{
    public float rotateSpeedx;
    public float rotateSpeedy;
    public float rotateSpeedz;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotateSpeedx,rotateSpeedy,rotateSpeedz));
    }
}
