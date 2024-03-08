
namespace MAUI.SpeechTherapy.Models.Alphba
{
    public class AlphbaWordModel
    {
        public int Id { get; set; }

        public string Word { get; set; }

        //0 first 1 middle 2 last
        public int Type { get; set; }

        public int AlphbaId { get; set; }

    }
}
