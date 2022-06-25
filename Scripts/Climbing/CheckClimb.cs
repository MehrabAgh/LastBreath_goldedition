using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClimb : MonoBehaviour
{
    public bool _isAvalible;
    private RaycastHit hit;
    [SerializeField] private float distanse;
    public Transform HitObject, resHit;
    private void Update()
    {
        _isAvalible = ClimbAccess();
    }
    private bool ClimbAccess()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distanse;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, forward, out hit, distanse))
        {
            HitObject = hit.collider.gameObject.transform;
            
            return true;
        }
        else
        {            
            return false;
        }
    }
}
