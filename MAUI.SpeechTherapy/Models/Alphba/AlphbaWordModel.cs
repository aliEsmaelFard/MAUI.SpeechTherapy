using SQLite;

namespace MAUI.SpeechTherapy.Models.Alphba
{
    public class AlphbaWordModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Word { get; set; }

        public int Type { get; set; }

        public int AlphbaId { get; set; }

    }
}
