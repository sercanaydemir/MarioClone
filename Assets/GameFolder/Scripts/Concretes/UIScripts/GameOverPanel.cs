using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.UIScripts
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void NoButtonClick()
        {
            GameManager.Instance.LoadingUIAndMenu(2);
        }
    }
}