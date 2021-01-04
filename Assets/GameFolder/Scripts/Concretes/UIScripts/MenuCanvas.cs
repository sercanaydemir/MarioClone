using System;
using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] private MenuPanel menuPanel;
        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandledSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandledSceneChanged;
        }

        private void HandledSceneChanged(bool obj)
        {
            menuPanel.gameObject.SetActive(obj);
        }

        
    }
}