using System;
using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject gamePlayObject;
        [SerializeField] private GameObject gameOverPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += GamePlayCanvas;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= GamePlayCanvas;
        }

        private void GamePlayCanvas(bool obj)
        {
            gamePlayObject.SetActive(!obj);
        }

        public void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}