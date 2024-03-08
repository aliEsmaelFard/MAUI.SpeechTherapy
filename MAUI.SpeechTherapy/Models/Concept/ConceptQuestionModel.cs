namespace MAUI.SpeechTherapy.Models.Concept
{
    public class ConceptQuestionModel
    {
       
        public int Id { get; set; }


        public string? RightAnswer { get; set; }

        public string? WrongAnswer { get; set; }

        public byte[]? Data { get; set; }

        public string? FileType { get; set; }

    }
}
