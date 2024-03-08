using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.AboutUs;

public partial class AboutProgrammerPage : ContentPage
{
    public AboutProgrammerPage()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        string value = Util.GetValueFromTapped<string>(e);
        OpenApp(value);
    }
     

    public void OpenApp(string email)
    {
        Launcher.OpenAsync($"mailto:{email}");
    }
}