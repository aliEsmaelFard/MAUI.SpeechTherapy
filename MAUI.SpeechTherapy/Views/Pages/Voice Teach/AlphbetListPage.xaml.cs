using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetListPage : ContentPage
{
	public AlphbetListPage()
	{
		InitializeComponent();
		BindingContext = this;

	}

	public string[] fakeData { get; set; } = { "آ", "م", "ز", "ل", "ق", "ث" };

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		string value = Util.GetValueFromTapped<string>(e);
		AlphbetOptionsPage.Letter = value;

		ContentView contentView = (ContentView)sender ;
		Util.ChangeItemListBackGround(contentView);

		//await Shell.Current.GoToAsync(nameof(AlphbetOptionsPage));
    }
}