using UnityEngine;
using CricketQuiz.Models;
using CricketQuiz.Managers;

namespace CricketQuiz.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MenuController menuController;
        [SerializeField] private GameView gameView;

        void Start()
        {
            Init();
        }

        private void Init()
        {
            menuController.Init();
            gameView.Init();
            GameManager.Instance.ResetGameTemporaryData();
            menuController.ToggleGame(false);
        }

        public void UpdateScore()
        {
            GameManager.Instance.currentScore++;
            gameView.UpdateScoreText();
        }

        public void StartQuiz()
        {
            if (GameManager.currentGameMode == GameMode.TIMEATTACK)
            {
                gameView.SetTimer();
                StartCoroutine(gameView.QuizTimer());
            }
            NextQuestion();
        }

        public bool CheckGameOver()
        {
            if (GameManager.currentGameMode == GameMode.TIMEATTACK)
            {
                return (GameManager.Instance.currentQuestion == GameManager.Instance.quizQuestions.quizData.Count);
            }
            else
            {
                {
                    return (GameManager.Instance.currentQuestion == 7);
                }
            }
        }

        public void GameOver()
        {
            menuController.ToggleGame(false);
            menuController.ToggleGameOver(true);
        }

        public void SetPrefs()
        {
            if (GameManager.Instance.currentScore > PlayerPrefs.GetInt(GameManager.Instance.highScorePref))
            {
                PlayerPrefs.SetInt(GameManager.Instance.highScorePref, GameManager.Instance.currentScore);
            }
        }


        public void NextQuestion()
        {
            GameManager.twoOpPowOption = 0;
            GameManager.isTwoOpEnable = false;
            gameView.DisplayQuestion();
            if (GameManager.currentGameMode == GameMode.TIMEATTACK)
            {
                gameView.AddTimer();
            }
        }
    }
}
