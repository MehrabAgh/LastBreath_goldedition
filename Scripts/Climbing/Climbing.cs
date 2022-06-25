using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [SerializeField]private ClimbResult aClimb;
    private PlayerConstructor player;
    [SerializeField]private int x;
    public int res;
    public bool _climbing;    
    private void Start()
    {
        player = PlayerConstructor.instance;
    }    
    void Update()
    {
        res = aClimb.resulter(x);
        print(res);
        if (Input.GetKeyDown(KeyCode.Space))
        {          
            if (res == 1)
            {
                player.EnableComponenets("isClimbing");
                player._rb.velocity += Vector3.forward * 15;
            }
            if (res == 2)
            {
                _climbing = true;
                player.EnableComponenets("isProClimbing");                
            }
        }
    }
}
