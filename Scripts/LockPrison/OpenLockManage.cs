using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockManage : MonoBehaviour
{
    [SerializeField] private GameObject[] pathLock;
    private GameObject clonePath;
    public bool _isLock = false, _isReset = false, _isSkiped;
    public static OpenLockManage ins;
    private RaycastHit hit;
    [SerializeField] private DotHandler point;
    [SerializeField] private int index;
    [SerializeField] private ActionEvents EndLockAction;
    private void Awake()
    {
        ins = this;
    }

    private void TechReset()
    {
        if (_isReset)
        {
            point.Func_Reset();
            clonePath.GetComponent<PathAuth>()._isEnd = false;
            clonePath.GetComponent<PathAuth>()._isMid = false;
        }
        else
        {
            point.Func_SetTime(30);
        }
    }
    private void ChangePath(GameObject[] coll, bool enabled_Change)
    {
        if (enabled_Change)
        {
            if (index == coll.Length)
            {
                // OpenDoor
                point.Func_SetTime(0);
                ActionManager.ins.LocaAction = EndLockAction;
            }
            if (index > 0)
            {
                coll[index - 1].gameObject.SetActive(false);
                coll[index].gameObject.SetActive(true);
                clonePath = coll[index];
                enabled_Change = false;
                index++;
            }
            else
            {
                coll[0].gameObject.SetActive(true);
                clonePath = coll[0];
                enabled_Change = false;
                index++;
            }

        }
    }
    private void EndPath()
    {
        _isLock = false;
        clonePath.GetComponent<PathAuth>()._isEnd = true;
        if (clonePath.GetComponent<PathAuth>()._isMid)
        {
            ChangePath(pathLock, true);
        }
 
    }
    private void Start()
    {
        ChangePath(pathLock, true);
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (_isSkiped)
        {
            clonePath.GetComponent<PathAuth>()._isMid = true;
            EndPath();
        }
        if (Physics.Raycast(ray, out hit))
        {
            var nameTarget = hit.transform.gameObject;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (nameTarget.name == "Ender" && _isLock)
                {
                    EndPath();
                }
                else if (nameTarget.name == "starter")
                {
                    _isLock = true;
                }
                else if (nameTarget.name == "mid" && _isLock)
                {
                    clonePath.GetComponent<PathAuth>()._isMid = true;
                }
                else if (nameTarget.name == "path_Lock")
                {
                    _isReset = false;
                }
                else
                {
                    _isLock = false;
                    _isReset = true;
                }
            }
        }       
        TechReset();
    }
}
