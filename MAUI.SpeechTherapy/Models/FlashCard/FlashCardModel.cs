
using SQLite;

namespace MAUI.SpeechTherapy.Models.FlashCard
{
    public class FlashCardModel
    {
        public int Id { get; set; }

        public string Name { get; set; }= string.Empty;
        public string NameAB { get; set; }= string.Empty;
        public string NameEN { get; set; }= string.Empty;

        public byte[]? Data { get; set; }

        public string FileType { get; set; } = string.Empty;

        [Ignore]
        public ImageSource Source { get; set; }

        [Ignore]
        public Color Color { get; set; }

    }
}
