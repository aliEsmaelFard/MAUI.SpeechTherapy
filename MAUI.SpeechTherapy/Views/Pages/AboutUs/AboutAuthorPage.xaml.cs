using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.AboutUs;

public partial class AboutAuthorPage : ContentPage
{
	public AboutAuthorPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		string value = MyUtils.GetValueFromTapped<string>(e);
        OpenApp(value);
    }


    public void OpenApp(string appName)
    {

        // Assuming you have the LinkedIn URL
        string linkedInUrl = "https://www.linkedin.com/in/wafa-delphi-a4b3b7aa/"; 
        string facebookUrl = "https://www.facebook.com/AlSubtainAcademy"; 

        switch (appName)
        {
            case "Telegram":
                Launcher.OpenAsync($"tg://resolve?domain=vafadelphi");
                break;
            case "WhatsApp":
                Launcher.OpenAsync($"https://wa.me/+9647852445121");
                break;
            case "Email":
                Launcher.OpenAsync($"mailto:vafa.delphi@gmail.com");
                break;
            case "link":
                Launcher.OpenAsync(new Uri(linkedInUrl));
                break;
            case "facebook":
                Launcher.OpenAsync(new Uri(facebookUrl));
                break;
            default:
                // Handle unsupported app name or fallback behavior
                break;
        }
    }
}