using SQLite;

namespace MAUI.SpeechTherapy.Models.Question
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string RightAnswer { get; set; }

        public string WrongAnswer { get; set; }

        public byte[]? Data { get; set; }

        public string? FileType { get; set; }

    }
}
