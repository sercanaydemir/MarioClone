using System;
using System.Linq;
using GameFolder.Scripts.Concretes.Combats;
using Project2.Controller;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        private CheckPointController[] _checkPoints;
        private Health _health;
        private void Awake()
        {
            _checkPoints = GetComponentsInChildren<CheckPointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }

        private void Start()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth,int maxHealth)
        {
            _health.transform.position = _checkPoints.LastOrDefault(x => x.IsPassed).transform.position;
        }
    }
}