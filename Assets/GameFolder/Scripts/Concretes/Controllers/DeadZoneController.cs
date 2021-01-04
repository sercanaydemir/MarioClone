using System;
using GameFolder.Scripts.Concretes.Combats;
using GameFolder.Scripts.Concretes.ExtensionMethods;
using UnityEngine;

namespace Project2.Controller
{
    public class DeadZoneController : MonoBehaviour
    {
        private Damage _damage;

        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Health health = other.ObjectHasHealth();

            if (health != null && other.WasHitBottomSide(0.75f))
            {
                _damage.HitTarget(health);
            }
        }
    }
}