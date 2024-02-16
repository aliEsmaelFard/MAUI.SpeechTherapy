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
		string value = Util.GetValueFromTapped<string>(e);
        OpenApp(value);
    }


    public void OpenApp(string appName)
    {
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
            default:
                // Handle unsupported app name or fallback behavior
                break;
        }
    }
}