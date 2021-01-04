using System;
using Project2.Controller;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Observers
{
    public class SoundObservers : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerController.OnPlayDeadSound += PlaySoundOneShot;
            EnemyController.OnEnemyDead += PlaySoundOneShot;
            GemController.OnPlayScoreSound += PlaySoundOneShot;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayDeadSound -= PlaySoundOneShot;
            EnemyController.OnEnemyDead -= PlaySoundOneShot;
            GemController.OnPlayScoreSound -= PlaySoundOneShot;
        }

        void PlaySoundOneShot(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}