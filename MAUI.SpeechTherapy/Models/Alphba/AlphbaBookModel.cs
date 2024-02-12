using SQLite;

namespace MAUI.SpeechTherapy.Models.Alphba
{
    public class AlphbaBookModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Text { get; set; }

        public int AlphbaId { get; set; }

        public int FileId { get; set; }
    }
}
