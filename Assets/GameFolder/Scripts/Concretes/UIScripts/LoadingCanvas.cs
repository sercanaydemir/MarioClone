using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class LoadingCanvas : MonoBehaviour
    {
        void Start()
        {
            GameManager.Instance.LoadingUIAndMenu(2f);
        }
    }
}