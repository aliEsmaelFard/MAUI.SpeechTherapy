namespace MAUI.SpeechTherapy.Models.SentenceMaking
{
    public class SentenceMakingModel
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int ObjectId { get; set; }

        public int VerbId { get; set; }

        public byte[]? ObjectData { get; set; }

        public string? ObjectFileType { get; set; }

        public byte[]? SubjectData { get; set; }

        public string? SubjectFileType { get; set; }

        public byte[]? VerbData { get; set; }

        public string? VerbFileType { get; set; }

    }
}
