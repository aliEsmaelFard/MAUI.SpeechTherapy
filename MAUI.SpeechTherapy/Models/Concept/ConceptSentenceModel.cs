namespace MAUI.SpeechTherapy.Models.Concept
{
    public class ConceptSentenceModel
    {
        
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string? Text { get; set; }

        public int FileId { get; set; }
    }
}
