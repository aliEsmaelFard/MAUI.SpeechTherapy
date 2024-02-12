using SQLite;

namespace MAUI.SpeechTherapy.Models.Question
{
    public class QuestionModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string RightAnswer { get; set; }

        public string WrongAnswer { get; set; }

        public int FileId { get; set; }
    }
}
