using Project2.Concretes.Controllers.Enemies;
using Project2.Concretes.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project2.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int score;

        public event System.Action<int> OnScoreChanged;
        public event System.Action OnSceneChanged;

        public static GameManager Instance { get; private set; }
        

        private void Awake()
        {
            SingletonThisGameObject();
        }
        private void Start()
        {
            
            
        }
        private void FixedUpdate()
        {
            
        }

        void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        public void IncreaseScore()
        {

            score++;
            OnScoreChanged?.Invoke(score);
           
        }
        public void StartGame()
        {
            score = 0;
            StartCoroutine(StartGameAsync());
            Time.timeScale = 1f;
        }
        IEnumerator StartGameAsync()
        {
            OnSceneChanged?.Invoke();
            yield return SceneManager.LoadSceneAsync("Enemies");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        public void ReturnMenu()
        {
            StartCoroutine(ReturnMenuAsync());
        }

        public IEnumerator ReturnMenuAsync()
        {
            OnSceneChanged?.Invoke();
            yield return SceneManager.LoadSceneAsync("Enemies");
        }

    }
}
