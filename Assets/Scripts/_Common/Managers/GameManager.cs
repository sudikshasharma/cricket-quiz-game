using UnityEngine;
using CricketQuiz.Models;

namespace CricketQuiz.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private string questionDataAddress;
        [HideInInspector] public int currentQuestion;
        [HideInInspector] public int currentQuestionAnswer;
        [HideInInspector] public int currentScore;
        [HideInInspector] public QuizQuestions quizQuestions;
        [HideInInspector] public QuizQuestions quizQuestionsData;

        public string highScorePref = "HighScore";
        public static int fiftyPow;
        public static int skip;
        public static int twoOpPow;
        public static int twoOpPowOption = 0;
        public static bool isTwoOpEnable;
        public static bool isInteractable = true;
        public static GameManager Instance;
        public static GameMode currentGameMode;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ResetGameTemporaryData()
        {
            currentQuestion = 0;
            currentScore = 0;
            currentQuestionAnswer = 0;
            skip = 0;
            twoOpPow = 0;
            quizQuestions = null;
            quizQuestionsData = null;
            isTwoOpEnable = false;
        }
        public void PopulateQuestions()
        {
            TextAsset questionTextAsset = Resources.Load(questionDataAddress) as TextAsset;
            string questions = questionTextAsset.text;
            quizQuestionsData = JsonUtility.FromJson<QuizQuestions>(questions);
            quizQuestions = JsonUtility.FromJson<QuizQuestions>(questions);
            int i = 0, dataIndex;
            while (quizQuestionsData.quizData.Count > 0)
            {
                dataIndex = Random.Range(0, quizQuestionsData.quizData.Count);
                quizQuestions.quizData[i].question = quizQuestionsData.quizData[dataIndex].question;
                quizQuestions.quizData[i].option1 = quizQuestionsData.quizData[dataIndex].option1;
                quizQuestions.quizData[i].option2 = quizQuestionsData.quizData[dataIndex].option2;
                quizQuestions.quizData[i].option3 = quizQuestionsData.quizData[dataIndex].option3;
                quizQuestions.quizData[i].option4 = quizQuestionsData.quizData[dataIndex].option4;
                quizQuestions.quizData[i].answerOption = quizQuestionsData.quizData[dataIndex].answerOption;
                quizQuestionsData.quizData.RemoveAt(dataIndex);
                i++;
            }
        }

    }
}
