using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody player;
    [SerializeField] private float   _speedx , _speedy, SpeedRotate, SpeedJump;
    private float SpeedX, SpeedY;
    private bool _jump;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void Forward(float speed, Rigidbody player)
    {
        //player.transform.Translate(-Vector3.forward / speed);
        player.velocity += new Vector3(0,0, Time.deltaTime / -speed);
    }
    private void Backward(float speed, Rigidbody player)
    {
        // player.transform.Translate(Vector3.forward / speed);
        player.velocity += Vector3.forward *Time.deltaTime / speed;
    }
    private void Left(float speed, Rigidbody player)
    {
        //player.transform.Translate(-Vector3.left / speed);
        player.velocity += new Vector3(Time.deltaTime / -0.5f, 0, 0);
    }
    private void Right(float speed, Rigidbody player)
    {
        //player.transform.Translate(Vector3.left / speed);
        player.velocity += new Vector3(Time.deltaTime / speed, 0, 0);
    }
    private void Jump(float speed, Rigidbody player)
    {
        if (_jump)
        {
            _jump = false;
            player.AddForce(0, speed, 0); 
        }
    }

    private void movement()
    {
        #region forward_Move 
        if (Input.GetKey(KeyCode.W))
        {            
            SpeedY = _speedy;
            player.velocity = new Vector3(SpeedX, 0, SpeedY);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {           
            SpeedY = 0;
        }
        #endregion
        //
        #region backward_Move 
        if (Input.GetKey(KeyCode.S))
        {           
            SpeedY = -_speedy;
            player.velocity += new Vector3(SpeedX, 0, SpeedY);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {                     
            SpeedY = 0;
        }
        #endregion
        //
        #region left_Move 
        if (Input.GetKey(KeyCode.D))
        {           
            SpeedX = _speedx;            
            player.velocity += new Vector3(SpeedX, 0, SpeedY);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {          
            SpeedX = 0;
        }
        #endregion
        //        
        #region right_Move 
        if (Input.GetKey(KeyCode.A))
        {         
            SpeedX = -_speedx;
            player.velocity += new Vector3(SpeedX, 0, SpeedY);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {           
            SpeedX = 0;
        }
        #endregion
        //
        #region Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(SpeedJump, player);
        }
        #endregion
    }
    private void Rotation()
    {       
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, SpeedRotate * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * SpeedRotate * Time.deltaTime);
        }
    }

    void Update()
    {     
        if (Input.GetKey(KeyCode.LeftShift)) SpeedX = _speedx - 20;
        movement();       
        //Rotation();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
    }
}
