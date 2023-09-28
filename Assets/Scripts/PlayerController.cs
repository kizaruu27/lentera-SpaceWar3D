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
        
        //camera boundaries
        private Vector2 minBounds;
        private Vector2 maxBounds;
        

        private void Update()
        {
            Move();
        }

        void Move()
        {
            _movement = new Vector3();
            _movement.x = _joyStick.Horizontal * _moveSpeed * Time.deltaTime;
            _movement.y = _joyStick.Vertical * _moveSpeed * Time.deltaTime;
            
            transform.Translate(_movement);
            
            if (_movement.x < 0)
            {
                Debug.Log("Left");
                _anim.Play("Left");
            }
            else if (_movement.x > 0)
            {
                Debug.Log("Right");
                _anim.Play("Right");
            }
            else
            {
                Debug.Log("Idle");
                _anim.Play("Idle");
            }

        }
    }
}


