using System;
namespace EXam
{
    public class QuizQuestionViewModel
    {
        // attributes
        private QuizQuestion _quizQuestion;

        // constructors
        public QuizQuestionViewModel(QuizQuestion quizQuestion, bool? response)
        {
            this.Response = response;
            _quizQuestion = quizQuestion;
        }

        // properties
        public string Question => _quizQuestion.Question;

        public bool Answer => _quizQuestion.Answer;

        public string Explanation => _quizQuestion.Explanation;

        public bool? Response { get; private set; }

        public bool IsCorrect => _quizQuestion.Answer == Response;
    }
}
