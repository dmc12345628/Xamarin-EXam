using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace EXam
{
    public partial class App : Application
    {
        public static Game CurrentGame;

        static Uri JsonQuestionsUri {
            get => new Uri("https://api.myjson.com/bins/16c8a9");
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage()
            {
                Title = "Home Page"
            });

            DependencyService.Register<NavigationService>();
        }

        protected override async void OnStart()
        {
            var fileHelper = DependencyService.Get<IFileHelper>();

            string questionsText;

            if (CrossConnectivity.Current.IsConnected)
            {
                questionsText = await new HttpClient().GetStringAsync(JsonQuestionsUri);
            }
            else
            {
                questionsText = await fileHelper.LoadLocalFileAsync("cachedquestions.json");
            }

            if (string.IsNullOrWhiteSpace(questionsText))
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;

                using (var stream = assembly.GetManifestResourceStream("EXam.Data.questions.json"))
                {
                    questionsText = new StreamReader(stream).ReadToEnd();
                }

                await fileHelper.SaveLocalFileAsync("cachequestions.json", questionsText);
            }

            var questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(questionsText);

            CurrentGame = new Game(questions);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
