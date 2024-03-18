using CommunityToolkit.Maui.Views;
using MAUI.SpeechTherapy.Models.Alphba;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetVideoPage : ContentPage
{
	public AlphbetVideoPage()
	{
		InitializeComponent();
	}
    public static AlphbaModel Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter.Name;
        mediaElement.Source = MediaSource.FromResource(Letter.VideoPath);
    }

    protected override void OnDisappearing()
    {
        mediaElement.Stop();
        base.OnDisappearing();
    }
}