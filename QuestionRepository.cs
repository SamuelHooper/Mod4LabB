using SQLite;
using System.Xml.Linq;

namespace Mod3LabB
{
    public class QuestionRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Question>();
            // Empties table and repopulates to prevent questions from stacking up each time app loads.
            DeleteAllQuestions();
            AddNewQuestion("Do you like to run?", 1, "running");
            AddNewQuestion("Do you like to swim?", 1, "swiming");
            AddNewQuestion("Do you work out?", 2, "workingout");
            AddNewQuestion("Do ride a bike?", 1, "biking");
        }

        public QuestionRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewQuestion(string questionText, int score, string imgFileName)
        {
            try
            {
                Init();

                // Basic validation
                if (string.IsNullOrEmpty(questionText))
                {
                    throw new Exception("Valid question required");
                } else if (string.IsNullOrEmpty(imgFileName))
                {
                    throw new Exception("Valid image file name required");
                }

                int result = conn.Insert(new Question(questionText, score, imgFileName));

                StatusMessage = $"{result} record(s) added (Question: {questionText})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {questionText}. Error: {ex.Message}";
            }
        }

        public List<Question> GetAllQuestions()
        {
            try
            {
                Init();
                return conn.Table<Question>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
            }

            return new List<Question>();
        }

        public void DeleteAllQuestions()
        {
            try
            {
                Init();
                conn.DeleteAll<Question>();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to remove data. {ex.Message}";
            }
        }
    }
}
