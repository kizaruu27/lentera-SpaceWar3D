using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        [SerializeField] private FloatingJoystick joyStick;
        [SerializeField] private Animator anim;
        [SerializeField] private float moveSpeed = 5f;
        private Vector3 movement;
        
        [SerializeField] private Canvas playerUICanvas;
        [SerializeField] private ScoreManager scoreManager;

        public static event Action OnTakeDamage;
        public static event Action OnGetShootItems;
        public static event Action OnGetHealthItems;
        public static event Action OnGetShield;

        private void OnEnable()
        {
            playerUICanvas.transform.parent = null;
            scoreManager.transform.parent = null;
        }

        private void Update()
        {
            Move();
        }

        void Move()
        {
            if (inputMethod == InputMethod.TOUCH)
            {
                movement = new Vector3();
                movement.x = joyStick.Horizontal * moveSpeed * Time.deltaTime;
                movement.y = joyStick.Vertical * moveSpeed * Time.deltaTime;
            
                transform.Translate(movement);
            } 
            else if (inputMethod == InputMethod.KEYBOARD)
            {
                joyStick.gameObject.SetActive(false);
                movement = new Vector3();
                movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
                movement.y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

                transform.Translate(movement);
            }
            
            if (movement.x < 0) anim.Play("Left");
            else if (movement.x > 0) anim.Play("Right");
            else anim.Play("ShipAnim");
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


