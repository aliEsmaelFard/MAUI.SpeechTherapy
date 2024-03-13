using SQLite;

namespace MAUI.SpeechTherapy.Models.Concept
{
    [Table("CategoryQuestionModel")]
    public class ConceptCategoryQuestionModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
