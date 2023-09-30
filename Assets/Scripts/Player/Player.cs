using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class Player : MonoBehaviour
    {
        enum InputMethod
        {
            KEYBOARD,
            TOUCH
        }

        [SerializeField] InputMethod inputMethod;
        
        [SerializeField] private FloatingJoystick _joyStick;
        [SerializeField] private Animator _anim;
        [SerializeField] private float _moveSpeed = 5f;
        
        private Vector3 _movement;

        public static event Action OnTakeDamage;
        public static event Action OnGetShootItems;
        public static event Action OnGetHealthItems;
        public static event Action OnGetShield;
        
        private void Update()
        {
            Move();
        }

        void Move()
        {
            if (inputMethod == InputMethod.TOUCH)
            {
                _movement = new Vector3();
                _movement.x = _joyStick.Horizontal * _moveSpeed * Time.deltaTime;
                _movement.y = _joyStick.Vertical * _moveSpeed * Time.deltaTime;
            
                transform.Translate(_movement);
            } 
            else if (inputMethod == InputMethod.KEYBOARD)
            {
                _movement = new Vector3();
                _movement.x = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
                _movement.y = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

                transform.Translate(_movement);
            }
            
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

            if (other.CompareTag("ShootItem"))
            {
                OnGetShootItems?.Invoke();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("HealthItem"))
            {
                OnGetHealthItems?.Invoke();   
                Destroy(other.gameObject);
            }

            if (other.CompareTag("ShieldItem"))
            {
                OnGetShield?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}


