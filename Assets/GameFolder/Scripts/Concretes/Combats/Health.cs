using System;
using GameFolder.Scripts.Concretes.UIScripts;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private int currentHealth;

        public int MaxHealth => maxHealth;
        public bool IsDead => currentHealth < 1;

        public event Action<int,int> OnHealthChanged;
        public event Action OnDead;
        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(Damage damage)
        {
            if (IsDead) return;
            
            currentHealth -= damage.HitDamage;
            
            if (IsDead)
            {
                Debug.Log("Workkk");
                OnDead?.Invoke();
            }
            else
            {
                OnHealthChanged?.Invoke((int)currentHealth,maxHealth);
            }
        }
    }
}