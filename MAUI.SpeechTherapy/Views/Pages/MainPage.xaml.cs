using MAUI.SpeechTherapy.Services.Alphba;
using MAUI.SpeechTherapy.Services.FlashCard;
using MAUI.SpeechTherapy.Services.SentenceMaking;

namespace MAUI.SpeechTherapy
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            SubjectService subject = new SubjectService();
            var s=subject.GetPageByPage(1,2);
            ObjectService objectService = new ObjectService();
            var o = objectService.GetPageByPage(1, 2);
            VerbService verbService = new VerbService();
            var v = verbService.GetPageByPage(1, 2);
            SentenceMakingService sent = new SentenceMakingService();
            var sm = sent.GetPageByPage(1,2);

            InitializeComponent();
        }


    }

}
