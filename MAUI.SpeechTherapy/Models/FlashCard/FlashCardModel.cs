
namespace MAUI.SpeechTherapy.Models.FlashCard
{
    public class FlashCardModel
    {
        public int Id { get; set; }

        public string Name { get; set; }= string.Empty;

        public byte[]? Data { get; set; }

        public string FileType { get; set; } = string.Empty;

    }
}
