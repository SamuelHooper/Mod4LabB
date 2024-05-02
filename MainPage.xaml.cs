namespace Mod3LabB
{
    public partial class MainPage : ContentPage
    {
        List<Question> Questions;
        int TotalScore = 0;
        int QuestionsAsked = 0;

        public MainPage()
        {
            // Team members: Daniel Shepard, Samuel Hooper
            Questions = App.QuestionRepo.GetAllQuestions();
            InitializeComponent();
            AskNextQuestion();
        }

        private void AnswerTrue(object sender, EventArgs e)
        {
            if (QuestionsAsked >= Questions.Count)
            {
                TotalScore += Questions[QuestionsAsked - 1].Score;
                TallyScore();
            } else
            {
                TotalScore += Questions[QuestionsAsked - 1].Score;
                AskNextQuestion();
            }
        }

        private void AnswerFalse(object sender, EventArgs e)
        {
            if (QuestionsAsked >= Questions.Count)
            {
                TallyScore();
            }
            else
            {
                AskNextQuestion();
            }
        }

        private void AskNextQuestion()
        {
            QuizOutput.Text = Questions[QuestionsAsked].QuestionText;
            QuizImage.Source = Questions[QuestionsAsked].Image + ".png";
            QuestionsAsked++;
        }

        private void TallyScore()
        {
            TrueBtn.IsVisible = false;
            FalseBtn.IsVisible = false;
            if (TotalScore == 0) 
            {
                QuizOutput.Text = "You are a couch potato...";
                QuizImage.Source = "couchpotato.png";
            } else if (TotalScore > 0 && TotalScore <= 2) 
            {
                QuizOutput.Text = "You are a somewhat active person.";
                QuizImage.Source = "inactive.png";
            } else if (TotalScore > 2 && TotalScore <= 4)
            {
                QuizOutput.Text = "You are an active person!";
                QuizImage.Source = "active.png";
            } else if (TotalScore > 4)
            {
                QuizOutput.Text = "You are a a true athlete!";
                QuizImage.Source = "athlete.png";
            }
        }

        async void GoToSwiperPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SwiperPage(), true);
        } 
    }

}
