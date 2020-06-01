using UnityEngine;
using CricketQuiz.Views;
using CricketQuiz.Models;
using System.Collections;
using CricketQuiz.Managers;

namespace CricketQuiz.Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private MenuView menuView;

        [SerializeField] private GameObject fadePanel;

        private IEnumerator StartGame()
        {
            GameManager.Instance.PopulateQuestions();
            gameController.StartQuiz();
            SetPower();
            yield return StartCoroutine(FadeEffect.FadeIn(fadePanel));
            ToggleMenu(false);
            ToggleGame(true);
            yield return StartCoroutine(FadeEffect.FadeOut(fadePanel));
        }

        private IEnumerator StartGameCareer()
        {
            GameManager.Instance.PopulateQuestions();
            gameController.StartQuiz();
            SetPower();
            yield return StartCoroutine(FadeEffect.FadeIn(fadePanel));
            ToggleMenu(false);
            ToggleGame(true);
            yield return StartCoroutine(FadeEffect.FadeOut(fadePanel));
        }

        private void SetPower()
        {
            GameManager.skip = menuView.GetPowerValue();
            GameManager.twoOpPow = menuView.GetPowerValue();
        }
        public void Init()
        {
            menuView.Init();
        }

        public void PlayCasualGame()
        {
            AudioManager.Instance.PlayMusic(4);
            GameManager.currentGameMode = GameMode.CAREER;
            menuView.ToggleMenu(false);
            menuView.ToggleLevelPanel(true);
        }

        public void PlayCareer()
        {
            AudioManager.Instance.PlayMusic(4);
            StartCoroutine(StartGameCareer());
        }

        public void PlayTimeAttackGame()
        {
            AudioManager.Instance.PlayMusic(4);
            GameManager.currentGameMode = GameMode.TIMEATTACK;
            StartCoroutine(StartGame());
        }

        public void ToggleMenu(bool status)
        {
            menuView.ToggleMenu(status);
        }
        public void ToggleGame(bool status)
        {
            menuView.ToggleGame(status);
        }
        public void ToggleGameOver(bool status)
        {
            menuView.ToggleGameOver(status);
        }
        public void Exit()
        {
            AudioManager.Instance.PlayMusic(4);
            Application.Quit();
        }

        public void Back()
        {
            AudioManager.Instance.PlayMusic(4);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}