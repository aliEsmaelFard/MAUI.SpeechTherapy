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
        string value = MyUtils.GetValueFromTapped<string>(e);
        OpenApp(value);
    }
       

    public void OpenApp(string email)
    {
        Launcher.OpenAsync($"mailto:{email}");
    }

    private async void  TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        try
        {
            // Assuming you have the LinkedIn URL
            string linkedInUrl = "https://www.linkedin.com/in/ali-esmael-fard-404a99280"; // Replace with the actual URL

            // Use the Launcher to open the URL
            await Launcher.OpenAsync(new Uri(linkedInUrl));
        }
        catch (Exception ex)
        {

        }
   ;
    }
}