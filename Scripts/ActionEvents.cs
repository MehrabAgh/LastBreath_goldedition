using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActionEvents : MonoBehaviour
{
    public UnityEvent @event;

    public void StartCamera(GameObject d)
    {
        d.transform.position = Vector3.Lerp(d.transform.position,new Vector3(-1.649594f, 1.58f, 1.62f), Time.deltaTime);
        d.transform.rotation = Quaternion.identity;
        d.GetComponent<CameraMove>().enabled = false;
    }
    public void OpenDoor(GameObject d)
    {
        d.transform.localPosition = Vector3.Lerp(d.transform.localPosition, new Vector3(3.519f, 7.49283f, -18.02758f), Time.deltaTime);
    }

    public void changeCamerainPrison(GameObject cam)
    {
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0.69f, 2.85f, -4.7f), Time.deltaTime /2);      
    }
}
