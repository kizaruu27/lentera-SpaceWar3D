using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joyStick;
        [SerializeField] private Animator _anim;
        [SerializeField] private float _moveSpeed = 5f;

        [SerializeField] private Rigidbody rb;
        private Vector3 _movement;

        private void Update()
        {
            Move();
        }

        void Move()
        {
            _movement = new Vector3();
            _movement.x = _joyStick.Horizontal * _moveSpeed * Time.deltaTime;
            _movement.y = _joyStick.Vertical * _moveSpeed * Time.deltaTime;

            rb.MovePosition(rb.position + _movement);
            
            // Debug.Log(_movement.x);

            if (_movement.x < 0)
            {
                Debug.Log("Left");
                _anim.Play("Left");
            }
            else if (_movement.x > 0)
            {
                Debug.Log("Right");
                _anim.Play("Right");
                // _anim.SetBool("isRight", true);
                // _anim.SetBool("isLeft", false);
            }
            else
            {
                Debug.Log("Idle");
                _anim.Play("Idle");
            }
        }
    }
}


