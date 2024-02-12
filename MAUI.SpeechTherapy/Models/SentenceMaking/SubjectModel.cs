using SQLite;

namespace MAUI.SpeechTherapy.Models.SentenceMaking
{
    public class SubjectModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }
    }
}
