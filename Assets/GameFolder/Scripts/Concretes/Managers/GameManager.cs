using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolder.Scripts.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int delayLevelTime;
        [SerializeField] private int score;
        public static  GameManager Instance { get; private set; }
        public event System.Action<bool> OnSceneChanged;
        public System.Action<int> OnScoreChanged;
        private void Awake()
        {
            SingletonObject();
        }

        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else 
                Destroy(this);
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            yield return SceneManager.UnloadSceneAsync(buildIndex);
            
            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed +=
                (AsyncOperation obj) =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
                };
            OnSceneChanged?.Invoke(false);
        }

        public void ExitGame()
        {
            Debug.Log("Exit Button Trigger");
            Application.Quit();
        }

        public void LoadingUIAndMenu(float delayTime)
        {
            StartCoroutine(LoadingUIMenu(delayTime));
        }

        IEnumerator LoadingUIMenu(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);

            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            
            OnSceneChanged?.Invoke(true);
        }

        public void IncreaseScore(int score = 0)
        {
            this.score += score;
            OnScoreChanged?.Invoke(this.score);
        }
    }
}