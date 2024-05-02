namespace Mod3LabB;

public partial class SwiperPage : ContentPage
{
    List<Question> Questions;
    int TotalScore = 0;
    int QuestionsAsked = 0;

    public SwiperPage()
	{
        Questions =
        [
            new Question("Do you like to run?", 1, "running"),
            new Question("Do you like to swim?", 1, "swiming"),
            new Question("Do you work out?", 2, "workingout"),
            new Question("Do ride a bike?", 1, "biking"),
        ];
        InitializeComponent();
        AskNextQuestion();
    }

    private void SwipeLeft(object sender, EventArgs e)
    {
        if (QuestionsAsked < Questions.Count)
        {
            TotalScore += Questions[QuestionsAsked - 1].Score;
            AskNextQuestion();
        }
        else if (QuestionsAsked == Questions.Count)
        {
            TotalScore += Questions[QuestionsAsked - 1].Score;
            QuestionsAsked++;
            TallyScore();
        } else
        {
            TallyScore();
        }
    }

    private void SwipeRight(object sender, EventArgs e)
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
        SwipeQuizOutput.Text = Questions[QuestionsAsked].QuestionText;
        SwipeImage.Source = Questions[QuestionsAsked].Image + ".png";
        QuestionsAsked++;
    }

    private void TallyScore()
    {
        if (TotalScore == 0)
        {
            SwipeQuizOutput.Text = "You are a couch potato...";
            SwipeImage.Source = "couchpotato.png";
        }
        else if (TotalScore > 0 && TotalScore <= 2)
        {
            SwipeQuizOutput.Text = "You are a somewhat active person.";
            SwipeImage.Source = "inactive.png";
        }
        else if (TotalScore > 2 && TotalScore <= 4)
        {
            SwipeQuizOutput.Text = "You are an active person!";
            SwipeImage.Source = "active.png";
        }
        else if (TotalScore > 4)
        {
            SwipeQuizOutput.Text = "You are a a true athlete!";
            SwipeImage.Source = "athlete.png";
        }
    }
}