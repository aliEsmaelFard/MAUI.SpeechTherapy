using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Services;
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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async Task LoadData()
    {
        ReadInfoDbService service = new ReadInfoDbService();

        DataList.Clear();
        GenericPageByPage<FlashCardCategory> res = await service.FlashCardCategoryListAsync(); 

        foreach (FlashCardCategory category in res.Items)
        {
            DataList.Add(category);
        }
       
    }

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        FlashCardCategory value = MyUtils.GetValueFromTapped<FlashCardCategory>(e);
        FlashCardListPage.FlashCardsTopic = value;

        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        await MyUtils.NavigateTo(nameof(FlashCardListPage));
    }


}