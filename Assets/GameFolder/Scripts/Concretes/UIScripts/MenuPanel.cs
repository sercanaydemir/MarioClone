using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }

        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}