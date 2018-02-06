using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EXam
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage() => InitializeComponent();

        public QuestionPage(QuestionPageViewModel questionPageViewModel)
        {
            InitializeComponent();

            BindingContext = questionPageViewModel;
        }
    }
}
