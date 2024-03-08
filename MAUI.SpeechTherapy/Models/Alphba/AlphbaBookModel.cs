using SQLite;

namespace MAUI.SpeechTherapy.Models.Alphba
{
    public class AlphbaBookModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public byte[] Data { get; set; }

        public string FileType { get; set; }

      //  public ImageSource Source { get; set; }
    }
}
