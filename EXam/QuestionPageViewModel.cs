using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace EXam
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        // attributes
        public event PropertyChangedEventHandler PropertyChanged;

        private Game _game;

        // constructors
        public QuestionPageViewModel(Game game)
        {
            _game = game;
            _game.Restart();

            TrueSelected = new Command(OnTrue);
            FalseSelected = new Command(OnFalse);
            NextSelected = new Command(OnNext, OnCanExecuteNext);
        }

        // properties
        public string Question
        {
            get => _game.CurrentQuestion.Question;
        }

        public string Response {
            get {
                if (_game.CurrentResponse == null)
                    return string.Empty;
                else {
                    return _game.CurrentQuestion.Answer == _game.CurrentResponse
                                ? "Correct!" : "Incorrect";
                }
            } 
        }

        public bool IsTrueFalseEnabled {
            get {
                return _game.CurrentResponse == null;
            }
        }

        public Command TrueSelected { get; set; }

        public Command FalseSelected { get; set; }

        public Command NextSelected { get; set; }

        async void OnTrue() {
            _game.OnTrue();
            RaiseAllPropertiesChanged();
            NextSelected.ChangeCanExecute();
        }

        async void OnFalse() {
            _game.OnFalse();
            RaiseAllPropertiesChanged();
            NextSelected.ChangeCanExecute();
        }

        async void OnNext() {
            if (_game.NextQuestion() == true)
            {
                NextSelected.ChangeCanExecute();
                RaiseAllPropertiesChanged();
            }
            else
            {
                var nav = DependencyService.Get<NavigationService>();
                if (nav != null)
                    await nav.GotoPageAsync(AppPage.ReviewPage);
            }
        }

        bool OnCanExecuteNext() {
            return _game.CurrentResponse != null;
        }

        void RaiseAllPropertiesChanged() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
    }
}
