using Bumptech.Glide.Util;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;

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

        }
    }

}
