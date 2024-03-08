using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.FlashCards;

public partial class FlashCardsTopicPage : ContentPage
{
	public FlashCardsTopicPage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    public string[] fakeData { get; set; } = { "ملابس", "الفاكهة", "طعام", "بندق", "الخضروات", "الحيوانات" };

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        string value = MyUtils.GetValueFromTapped<string>(e);
        FlashCardListPage.Topic = value;

        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        await MyUtils.NavigateTo(nameof(FlashCardListPage));
    }


}