using System;

using Xamarin.Forms;

namespace EXam
{
    public class HomePage : ContentPage
    {
        public bool IsStartButtonEnabled
        {
            get => btnStart.IsEnabled;
            set => btnStart.IsEnabled = value;
        }

        Button btnStart;

        public HomePage()
        {
            var absoluteLayout = new AbsoluteLayout();

            Content = absoluteLayout;

            Image imgBackground = new Image();
            imgBackground.Source = ImageSource.FromResource("EXam.Images.background.jpg");
            imgBackground.Aspect = Aspect.AspectFill;

            absoluteLayout.Children.Add(imgBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);

            btnStart = new Button();
            btnStart.Text = "Start EXam!";
            btnStart.BackgroundColor = Color.White;
            btnStart.TextColor = Color.FromHex("#0892D0");
            btnStart.Font = Font.SystemFontOfSize(NamedSize.Medium);

            absoluteLayout.Children.Add(btnStart, new Rectangle(0.5, 0.5, 200, 50), AbsoluteLayoutFlags.PositionProportional);

            NavigationPage.SetHasNavigationBar(this,false);

            btnStart.Clicked += ShowQuestionPage;
        }

        async public void ShowQuestionPage(Object sender, EventArgs e) {
            var nav = DependencyService.Get<NavigationService>();
            if (nav != null)
                await nav.GotoPageAsync(AppPage.QuestionPage);
        }
    }
}

