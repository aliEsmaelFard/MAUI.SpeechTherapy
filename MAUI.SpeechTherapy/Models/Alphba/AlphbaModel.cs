using SQLite;

namespace MAUI.SpeechTherapy.Models.Alphba
{
    public class AlphbaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public int FileId { get; set; }

    }
}
