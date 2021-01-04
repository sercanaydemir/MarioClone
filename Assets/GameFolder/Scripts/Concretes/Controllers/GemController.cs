using System;
using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;

namespace Project2.Controller
{
    public class GemController : MonoBehaviour
    {
        [SerializeField] private int score;
        [SerializeField] private AudioClip audioClip;

        public static event System.Action<AudioClip> OnPlayScoreSound;
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.IncreaseScore(score);
                OnPlayScoreSound?.Invoke(audioClip);
                Destroy(this.gameObject);
            }
        }
    }
}