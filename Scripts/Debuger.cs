using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuger : MonoBehaviour
{
    public static Debuger ins;

    private void Awake()
    {
        ins = this;
    }
    public void debug()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1;
        Vector3 down = transform.TransformDirection(-Vector3.up) * 0.5f;
        Debug.DrawRay(transform.position, down, Color.green);
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
