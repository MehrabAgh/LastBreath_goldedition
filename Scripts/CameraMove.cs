using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform pivot;
    public float speed;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pivot.position, Time.deltaTime / speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, pivot.rotation, Time.deltaTime / speed);
        var rotSub = transform.rotation;
        var k = rotSub.eulerAngles;
        k.y = 0;
        rotSub.eulerAngles = k;
        transform.rotation = rotSub;
    }
}
