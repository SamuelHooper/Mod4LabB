
using SQLite;

namespace Mod3LabB
{
    [Table("question")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Score { get; set; }
        public string Image { get; set; }

        public Question() { }
        public Question(string questionText, int score, string image) 
        {
            QuestionText = questionText;
            Score = score;
            Image = image;
        }
    }
}
