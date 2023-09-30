using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;

namespace SpaceWar3D
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip explosionClip;
        [SerializeField] private AudioClip itemClip;

        public void PlayShootingClip(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void PlayExplosionClip()
        {
            audioSource.PlayOneShot(explosionClip);
        }

        public void PlayItemClip()
        {
            audioSource.PlayOneShot(itemClip);
        }
    }
}

