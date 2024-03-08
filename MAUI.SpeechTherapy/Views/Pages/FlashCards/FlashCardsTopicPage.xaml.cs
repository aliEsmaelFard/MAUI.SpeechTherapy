using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.FlashCards;

public partial class FlashCardsTopicPage : ContentPage
{
    public ObservableCollection<FlashCardCategory> DataList { get; set; } = new ObservableCollection<FlashCardCategory>();

    public FlashCardsTopicPage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    
 


    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        string value = MyUtils.GetValueFromTapped<string>(e);
        FlashCardListPage.Topic = value;

        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        await MyUtils.NavigateTo(nameof(FlashCardListPage));
    }


}