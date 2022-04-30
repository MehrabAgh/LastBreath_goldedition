using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotHandler : MonoBehaviour
{    
    private bool _isDrag;
    public Camera cam;
    private Vector3 posStart;
    [SerializeField]private TrailRenderer eff;
    public void Func_Reset()
    {
        transform.position = posStart;
        eff.time = 0;
    }
    public void Func_SetTime(float time)
    {
        eff.time = time;
    }
    private void Start()
    {
        posStart = transform.position;
        eff = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (OpenLockManage.ins._isLock)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDrag = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDrag = false;
            }
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (_isDrag)
            {
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    transform.position = raycastHit.point;                    
                }
            }
        }
    }
   
}
