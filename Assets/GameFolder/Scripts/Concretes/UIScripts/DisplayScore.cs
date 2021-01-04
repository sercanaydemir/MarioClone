using System;
using GameFolder.Scripts.Concretes.Managers;
using TMPro;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class DisplayScore : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChange;
            GameManager.Instance.OnScoreChanged.Invoke(0);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChange;
        }

        private void HandleScoreChange(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}