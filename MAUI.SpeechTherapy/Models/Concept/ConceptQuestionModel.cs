namespace MAUI.SpeechTherapy.Models.Concept
{
    public class ConceptQuestionModel
    {
       
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string? RightAnswer { get; set; }

        public string? WrongAnswer { get; set; }

        public int FileId { get; set; }
    }
}
