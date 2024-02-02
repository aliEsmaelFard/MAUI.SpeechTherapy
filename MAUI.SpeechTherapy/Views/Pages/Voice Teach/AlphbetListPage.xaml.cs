namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetListPage : ContentPage
{
	public AlphbetListPage()
	{
		InitializeComponent();
		BindingContext = this;

	}

	public string[] fakeData { get; set; } = { "آ", "م", "ز", "ل", "ق", "ث" };

    private void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var tapEventArgs = (TappedEventArgs)e;
        string section = (string)tapEventArgs.Parameter;
    }
}