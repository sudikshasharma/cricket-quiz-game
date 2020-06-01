using UnityEngine;
using UnityEngine.UI;
using CricketQuiz.Managers;
using CricketQuiz.Controllers;

namespace CricketQuiz.Views
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private MenuController menuController;
        [SerializeField] private Button playCasualBtn;
        [SerializeField] private Button playTimeAttackBtn;
        [SerializeField] private Button exitBtn;
        [SerializeField] private Button levelBackBtn;
        [SerializeField] private Button gameBackBtn;
        [SerializeField] private Button gameOverExitBtn;
        [SerializeField] private Button gameOverBackBtn;

        [SerializeField] private Button level1Btn;
        [SerializeField] private Button level2Btn;
        [SerializeField] private Button level3Btn;
        [SerializeField] private Button level4Btn;
        [SerializeField] private Button level5Btn;

        [SerializeField] private Text highScoreText;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject levelPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private int powerCount;

        private void LoadPrefs()
        {
            highScoreText.text = PlayerPrefs.GetInt(GameManager.Instance.highScorePref).ToString();
        }
        public void Init()
        {
            LoadPrefs();
            playCasualBtn.onClick.AddListener(menuController.PlayCasualGame);
            playTimeAttackBtn.onClick.AddListener(menuController.PlayTimeAttackGame);
            exitBtn.onClick.AddListener(menuController.Exit);
            gameBackBtn.onClick.AddListener(menuController.Back);
            gameOverExitBtn.onClick.AddListener(menuController.Exit);
            gameOverBackBtn.onClick.AddListener(menuController.Back);
            levelBackBtn.onClick.AddListener(menuController.Back);
            level1Btn.onClick.AddListener(menuController.PlayCareer);
            level2Btn.onClick.AddListener(menuController.PlayCareer);
            level3Btn.onClick.AddListener(menuController.PlayCareer);
            level4Btn.onClick.AddListener(menuController.PlayCareer);
            level5Btn.onClick.AddListener(menuController.PlayCareer);
        }

        public void ToggleMenu(bool status)
        {
            menuPanel.SetActive(status);
        }

        public void ToggleGame(bool status)
        {
            gamePanel.SetActive(status);
        }

        public void ToggleLevelPanel(bool status)
        {
            levelPanel.SetActive(status);
        }

        public int GetPowerValue()
        {
            return powerCount;
        }

        public void ToggleGameOver(bool status)
        {
            gameOverPanel.SetActive(status);
        }
    }
}
