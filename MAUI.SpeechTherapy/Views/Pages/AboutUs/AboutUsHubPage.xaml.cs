using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.AboutUs;

public partial class AboutUsHubPage : ContentPage
{
	public AboutUsHubPage()
	{
		InitializeComponent();
	}

    private async void AuthorGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await MyUtils.NavigateTo(nameof(AboutAuthorPage));
    }

    private async void ProgrammerGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await MyUtils.NavigateTo(nameof(AboutProgrammerPage));
    }
}