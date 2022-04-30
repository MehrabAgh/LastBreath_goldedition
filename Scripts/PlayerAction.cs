using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "action")
        {
            ActionManager.ins.LocaAction = other.GetComponent<ActionEvents>();
        }
    }
}
