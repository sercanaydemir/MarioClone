using System;
using UnityEngine;

namespace Project2.Controller
{
    public class CheckPointController : MonoBehaviour
    {
        private bool _isPassed;
        public bool IsPassed => _isPassed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                _isPassed = true;
            }
        }
    }
}