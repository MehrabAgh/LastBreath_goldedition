using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public ActionEvents LocaAction;
    public static ActionManager ins;

    private void Awake()
    {
        ins = this;        
        StartCoroutine(update(.01f));
    }   
    IEnumerator update(float t)
    {
        while (true)
        {
            yield return new WaitForSeconds(t);
            if (LocaAction != null)
            {
                LocaAction.@event.Invoke();     
            }
        }
        
       
    }

}
