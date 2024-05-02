namespace Mod3LabB
{
    public partial class App : Application
    {
        public static QuestionRepository QuestionRepo { get; private set; }
        public App(QuestionRepository repo)
        {
            InitializeComponent();

            QuestionRepo = repo;

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
