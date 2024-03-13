

using SQLite;

namespace MAUI.SpeechTherapy.Models.Concept
{
    [Table("CategorySentenceModel")]
    public class ConceptCategorySentenceModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
