using MAUI.SpeechTherapy.Services.Alphba;
using MAUI.SpeechTherapy.Services.FlashCard;

namespace MAUI.SpeechTherapy
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
           FlashCardService alphbaService = new FlashCardService();
            var x= alphbaService.GetPageByPage(1,1,1);

            InitializeComponent();
        }


    }

}
