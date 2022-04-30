using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody player;
    [SerializeField] private float Speed, SpeedRotate, SpeedJump;
    private float _speed;
    private bool _ismoveX, _ismoveY, _jump;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        _speed = Speed;
    }

    private void Forward(float speed, Rigidbody player)
    {
        player.transform.Translate(-Vector3.forward / speed);
    }
    private void Backward(float speed, Rigidbody player)
    {
        player.transform.Translate(Vector3.forward / speed);
    }
    private void Left(float speed, Rigidbody player)
    {
        player.transform.Translate(-Vector3.left / speed);
    }
    private void Right(float speed, Rigidbody player)
    {
        player.transform.Translate(Vector3.left / speed);
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
            _ismoveY = true;
            Forward(Speed, player);
        }
        if (Input.GetKeyUp(KeyCode.W))
            _ismoveY = false;
        #endregion
        //
        #region backward_Move 
        if (Input.GetKey(KeyCode.S))
        {
            _ismoveY = true;
            Backward(Speed, player);
        }
        if (Input.GetKeyUp(KeyCode.S))
            _ismoveY = false;
        #endregion
        //
        #region left_Move 
        //if (Input.GetKey(KeyCode.D))
        //{
        //    _ismoveX = true;
        //    Left(Speed, player);
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //    _ismoveX = false;
        #endregion
        //        
        #region right_Move 
        //if (Input.GetKey(KeyCode.A))
        //{
        //    _ismoveX = true;
        //    Right(Speed, player);
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //    _ismoveX = false;
        #endregion

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(SpeedJump, player);
        }
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
        if (_ismoveX && _ismoveY)Speed = _speed + 5;
        
        else Speed = _speed;
        
        if (Input.GetKey(KeyCode.LeftShift)) Speed = _speed - 20;

        movement();
        Rotation();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
    }
}
