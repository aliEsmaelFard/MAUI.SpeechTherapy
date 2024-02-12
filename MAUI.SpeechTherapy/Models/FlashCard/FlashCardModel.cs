using SQLite;

namespace MAUI.SpeechTherapy.Models.FlashCard
{
    public class FlashCardModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        [Column("CategoryId")]
        public int FlashCardCategoryId { get; set; }

    }
}
