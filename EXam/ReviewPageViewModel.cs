using System;
using System.Collections.Generic;

namespace EXam
{
    public class ReviewPageViewModel
    {
        public ReviewPageViewModel(Game game)
        {
            QuestionViewModels = new List<QuizQuestionViewModel>();

            for (int i = 0; i < game.NumberOfQuestions; i++)
            {
                QuestionViewModels.Add(new QuizQuestionViewModel(game.Questions[i], game.Responses[i]));
            }
        }

        // properties
        public List<QuizQuestionViewModel> QuestionViewModels { get; set; }
    }
}
