using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joyStick;
        [SerializeField] private Animator _anim;
        [SerializeField] private float _moveSpeed = 5f;
        
        private Vector3 _movement;

        public event Action OnTakeDamage;
        
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
            
            if (_movement.x < 0) _anim.Play("Left");
            else if (_movement.x > 0) _anim.Play("Right");
            else _anim.Play("Idle");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyProjectile") || other.CompareTag("Enemy"))
            {
                OnTakeDamage?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}


