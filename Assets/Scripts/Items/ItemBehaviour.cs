using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class ItemBehaviour : MonoBehaviour
    {
        [SerializeField] private float itemLifeTime;
    
        void Start()
        {
            Destroy(gameObject, itemLifeTime);
        }
    }
}
