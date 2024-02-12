using SQLite;

namespace MAUI.SpeechTherapy.Models.FlashCard
{
    public class FlashCardCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

      
    }
}
