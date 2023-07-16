using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoRoteObj : MonoBehaviour
{
    public float rotateSpeed;

    private bool hit = false;

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hit = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tomato" && hit == true)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed));
        }
    }

    private void Update()
    {
        if(!(transform.localEulerAngles.z < 2 && transform.localEulerAngles.z > -2) && hit == false)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed));
        }
    }
}
