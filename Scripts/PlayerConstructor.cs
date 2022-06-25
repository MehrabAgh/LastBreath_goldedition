using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RootMotion.FinalIK;

public class PlayerConstructor : MonoBehaviour
{
    public Transform _trans;
    public Animator _anim;
    public Rigidbody _rb;
    public FullBodyBipedIK IK;
    public ClimbResult climbChecker;
    public static PlayerConstructor instance;

    [SerializeField]private Transform effLeft , effRight;
    private void Awake()
    {        
        instance = this;
    }

    public void EnableComponenets(string param)
    {
        _anim.applyRootMotion = true;
        _rb.useGravity = false;
        _anim.SetBool(param, true);
        GetComponent<Movement>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
    public void DisableComponenets(string param)
    {
        _anim.applyRootMotion = false;
        _rb.useGravity = true;
        _anim.SetBool(param, false);
        GetComponent<Movement>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }
    public void DefultIKElement()
    {
        IK.solver.leftHandEffector.target = effLeft;
        IK.solver.rightHandEffector.target = effRight;
    }
}
