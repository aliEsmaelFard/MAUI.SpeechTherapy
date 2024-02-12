using SQLite;

namespace MAUI.SpeechTherapy.Models.SentenceMaking
{
    public class SentenceMakingModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int ObjectId { get; set; }

        public int VerbId { get; set; }
    }
}
