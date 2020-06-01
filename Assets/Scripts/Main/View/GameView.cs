using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CricketQuiz.Managers;
using CricketQuiz.Controllers;

public class GameView : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Button optionA;
    [SerializeField] private Button optionB;
    [SerializeField] private Button optionC;
    [SerializeField] private Button optionD;
    [SerializeField] private Button twoPow;
    [SerializeField] private Button skipPow;

    [SerializeField] private Text questionText;
    [SerializeField] private Text optionTextA;
    [SerializeField] private Text optionTextB;
    [SerializeField] private Text optionTextC;
    [SerializeField] private Text optionTextD;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text currentQuestionText;
    [SerializeField] private Text currentTimerText;
    [SerializeField] private Text currentTimerTextTitle;
    [SerializeField] private Text finalScoreText;
    [SerializeField] private float timerValue;
    [SerializeField] private float timerIncrementalValue;
    private int correctAnswer;


    private IEnumerator CheckAnswer(Button optionBtn)
    {
        if (gameController.CheckGameOver() || GameManager.Instance.currentQuestionAnswer != correctAnswer)
        {
            if (GameManager.isTwoOpEnable)
            {
                GameManager.twoOpPowOption = GameManager.Instance.currentQuestionAnswer;
                GameManager.isTwoOpEnable = false;
                yield break;
            }
            if (GameManager.twoOpPowOption == GameManager.Instance.currentQuestionAnswer)
            {
                yield break;
            }
            if (!gameController.CheckGameOver())
            {
                GameManager.isInteractable = false;
                AudioManager.Instance.PlayMusic(1);
                yield return StartCoroutine(BlipEffect.Blipper(optionBtn.gameObject, new Color32(231, 80, 78, 255)));
                GameManager.isInteractable = true;
            }
            GameOver();
            yield break;
        }
        AudioManager.Instance.PlayMusic(0);
        GameManager.isInteractable = false;
        yield return StartCoroutine(BlipEffect.Blipper(optionBtn.gameObject, new Color32(255, 255, 255, 255)));
        GameManager.isInteractable = true;
        gameController.UpdateScore();
        GameManager.Instance.currentQuestion++;
        NextQuestion();
    }

    private void NextQuestion()
    {
        gameController.NextQuestion();
    }

    private void PlayerAnswer(int ans, Button optionBtn)
    {
        if (GameManager.isInteractable)
        {
            GameManager.Instance.currentQuestionAnswer = ans;
            StartCoroutine(CheckAnswer(optionBtn));
        }
    }

    private void SetListener()
    {
        optionA.onClick.AddListener(() => PlayerAnswer(1, optionA));
        optionB.onClick.AddListener(() => PlayerAnswer(2, optionB));
        optionC.onClick.AddListener(() => PlayerAnswer(3, optionC));
        optionD.onClick.AddListener(() => PlayerAnswer(4, optionD));
        twoPow.onClick.AddListener(TwoOptionPower);
        skipPow.onClick.AddListener(SkipPower);
    }

    private void TwoOptionPower()
    {
        if (GameManager.twoOpPow > 0)
        {
            AudioManager.Instance.PlayMusic(3);
            GameManager.isTwoOpEnable = true;
        }
        GameManager.twoOpPow--;
    }
    private void SkipPower()
    {
        if (GameManager.skip > 0)
        {
            AudioManager.Instance.PlayMusic(3);
            GameManager.Instance.currentQuestion++;
            NextQuestion();
        }
        GameManager.skip--;
    }

    private void SetFinalScoreText()
    {
        finalScoreText.text = GameManager.Instance.currentScore.ToString();
    }

    private void GameOver()
    {
        SetFinalScoreText();
        gameController.SetPrefs();
        gameController.GameOver();
    }

    public IEnumerator QuizTimer()
    {
        while (timerValue > 0)
        {
            --timerValue;
            currentTimerText.text = timerValue.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        GameOver();
    }

    public void Init()
    {
        SetListener();
        currentTimerText.text = timerValue.ToString();
    }
    public void DisplayQuestion()
    {
        UpdateQuestionText();
        questionText.text = GameManager.Instance.quizQuestions.quizData[GameManager.Instance.currentQuestion].question;
        optionTextA.text = GameManager.Instance.quizQuestions.quizData[GameManager.Instance.currentQuestion].option1;
        optionTextB.text = GameManager.Instance.quizQuestions.quizData[GameManager.Instance.currentQuestion].option2;
        optionTextC.text = GameManager.Instance.quizQuestions.quizData[GameManager.Instance.currentQuestion].option3;
        optionTextD.text = GameManager.Instance.quizQuestions.quizData[GameManager.Instance.currentQuestion].option4;
        correctAnswer = GameManager.Instance.quizQuestions.quizData[GameManager.Instance.currentQuestion].answerOption;
    }
    public void UpdateScoreText()
    {
        currentScoreText.text = GameManager.Instance.currentScore.ToString();
    }
    public void UpdateQuestionText()
    {
        currentQuestionText.text = (GameManager.Instance.currentQuestion + 1).ToString() + ".";
    }
    public void AddTimer()
    {
        timerValue += timerIncrementalValue;
    }

    public void SetTimer()
    {
        currentTimerText.gameObject.SetActive(true);
        currentTimerTextTitle.gameObject.SetActive(true);
    }
}
