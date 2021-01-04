using System;
using TMPro;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class DisplayHealth : MonoBehaviour
    {
        private TextMeshProUGUI _healthText;

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        public void WriteHealth(int currentHealth,int maxHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }
}