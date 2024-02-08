using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.FlashCards;

public partial class FlashCardsTopicPage : ContentPage
{
	public FlashCardsTopicPage()
	{
		InitializeComponent();
	}

    public string[] fakeData { get; set; } = { "ملابس", "الفاكهة", "طعام", "بندق", "الخضروات", "الحيوانات" };

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        string value = Util.GetValueFromTapped<string>(e);
        AlphbetOptionsPage.Letter = value;

        ContentView contentView = (ContentView)sender;
        Util.ChangeItemListBackGround(contentView);

        await Shell.Current.GoToAsync(nameof(AlphbetOptionsPage));
    }
}