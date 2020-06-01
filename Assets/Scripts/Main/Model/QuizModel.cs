using System;
using System.Collections.Generic;

namespace CricketQuiz.Models
{
    [System.Serializable]
    public class QuizModel
    {
        public String question;
        public String option1;
        public String option2;
        public String option3;
        public String option4;
        public int answerOption;
    }
    [System.Serializable]
    public class QuizQuestions
    {
        public List<QuizModel> quizData;
    }

    public enum GameMode
    {
        CAREER,
        TIMEATTACK
    }
}
