using SQLite;

namespace MAUI.SpeechTherapy.Models.File
{
    public class FileModel
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string FileType { get; set; }

        public string Entity { get; set; }

        // 0 is video; 1 is photo
        public int type { get; set; }
    }
}
