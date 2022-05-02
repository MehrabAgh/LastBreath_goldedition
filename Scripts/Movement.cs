using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody player;
    [SerializeField] private float _speedx , _speedUper, SpeedRotate, SpeedJump;
    private float SpeedX;
    private bool _jump;
    private Vector3 MoveDir;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        SpeedX = _speedx;
    }
 
    private void Jump(float speed, Rigidbody player)
    {
        if (_jump)
        {
            _jump = false;
            player.AddForce(0, speed, 0); 
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) _speedx = _speedUper;
        if (Input.GetKeyUp(KeyCode.LeftShift)) _speedx = SpeedX;
        if (Input.GetAxis("Jump") > 0)
        {
            if (_jump)
            {
                player.AddForce(transform.up * SpeedJump);
                _jump = false;
            }
        }
    }
    void Move(Rigidbody Player)
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");    
        Vector3 movement = new Vector3(hMove, 0.0f, vMove);
        Player.velocity = movement.normalized * _speedx + new Vector3(0.0f, Player.velocity.y, 0.0f);
    }
    private void FixedUpdate()
    {
        Move(player);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
    }
}
