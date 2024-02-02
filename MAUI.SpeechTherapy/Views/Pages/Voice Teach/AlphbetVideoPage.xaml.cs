namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetVideoPage : ContentPage
{
	public AlphbetVideoPage()
	{
		InitializeComponent();
	}
    public static string Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter;
    }

    protected override void OnDisappearing()
    {
        mediaElement.Stop();
        base.OnDisappearing();
    }
}