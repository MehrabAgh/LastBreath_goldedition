using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerConstructor player;
    [SerializeField] private float _speedx, _speedUper, SpeedJump;
    private float SpeedX, _setAnimfloat;
    [SerializeField]private bool _jump, _speedUping , _Heigt;    
    private RaycastHit hit;
    public bool aa;
    void Start()
    {
        player = PlayerConstructor.instance;
        SpeedX = _speedx;
    }

    private void Jump(float speed, Rigidbody player,Animator animator)
    {                
        animator.SetBool("isJumping", true);
        player.AddForce(transform.up * speed);            
    }

    public void DisableThis()
    {
        this.enabled = false;
        player._anim.SetFloat("posX", 0);
    }
    void Update()
    {
        #region SpeedUpper
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedx = _speedUper;
            _speedUping = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speedx = SpeedX;
            _speedUping = false;
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jump)
            {
                Jump(SpeedJump, player._rb, player._anim);
                _jump = false;
            }
        }
        if (!Physics.Raycast(player._trans.position, -transform.up, out hit, .5f))
        {
            _Heigt = true;     
        }
        player._anim.SetBool("isJumping", _Heigt);
    }
    void Move(Rigidbody Player , bool _climbing)
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");
        if (player._anim)
        {
            var ev = hMove != 0 || vMove != 0;

            if (ev)
            {
                if (_speedUping)
                {
                    _setAnimfloat += Time.deltaTime * 2;
                    _setAnimfloat = Mathf.Clamp(_setAnimfloat, 0, 2);
                }
                else
                {
                    if (_setAnimfloat > 1)
                    {
                        _setAnimfloat -= Time.deltaTime * 2;
                        _setAnimfloat = Mathf.Clamp(_setAnimfloat, 1, 2);
                    }
                    else
                    {
                        _setAnimfloat += Time.deltaTime * 2;
                        _setAnimfloat = Mathf.Clamp(_setAnimfloat, 0, 1);
                    }
                }
            }            
            else
            {
                _setAnimfloat -= Time.deltaTime*3;
                _setAnimfloat = Mathf.Clamp(_setAnimfloat, 0, 2);
            }

            player._anim.SetFloat("posX", _setAnimfloat);
        }
        if (!_climbing)
        {
            Vector3 movement = new Vector3(hMove, 0.0f, vMove).normalized;
            var moveforRot = movement;
            Player.velocity = movement * _speedx + new Vector3(0.0f, Player.velocity.y, 0.0f);

            if (moveforRot != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveforRot);
                player._trans.rotation = Quaternion.Slerp(player._trans.rotation, newRotation, Time.deltaTime * 8);
            }
        }
        else
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, vMove).normalized;
            var moveforRot = movement;
            Player.velocity = movement * _speedx + new Vector3(0.0f,0.0f, Player.velocity.z);
        }
    }
    private void FixedUpdate()
    {
        Move(player._rb , aa);
    }
    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
        _Heigt = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        _Heigt = false;
    }
}
