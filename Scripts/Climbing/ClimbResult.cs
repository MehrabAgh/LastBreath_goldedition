using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbResult : MonoBehaviour
{
    public List<CheckClimb> checks;    
    public int resulter(int x)
    {
        for (int i = 0; i < checks.Count; i++)
        {
            if (checks[i]._isAvalible)
            {
                x = i+1;               
            }
            if(x == 1)
            {
                return 2;
            }
            if (x == 2) {
                return 1;
            }
            if (x == 3)
            {
                return 3;
            }
        }
        return -1;
    }
}
