using MAUI.SpeechTherapy.Utils;
using MAUI.SpeechTherapy.Views.Pages.Sentence_Makng;

namespace MAUI.SpeechTherapy
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {

            InitializeComponent();

        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (MyUtils.FirstRun)
            {
                // Perform an action.
                MyUtils.FillDataBase();
                MyUtils.FirstRun = false;
            }
            SentenceMakingPage.CurrentPage = 1;
        }
    }

}
