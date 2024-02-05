namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetSentencePage : ContentPage
{
	public AlphbetSentencePage()
	{
		InitializeComponent();
	}

    public static string Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter;

    }



}