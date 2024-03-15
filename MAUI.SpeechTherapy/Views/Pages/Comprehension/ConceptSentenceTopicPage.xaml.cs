using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Concept;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Comprehension;

public partial class ConceptSentenceTopicPage : ContentPage
{

    public ObservableCollection<ConceptCategorySentenceModel> DataList { get; set; } = new ObservableCollection<ConceptCategorySentenceModel>();
    public ConceptSentenceTopicPage()
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
        GenericPageByPage<ConceptCategorySentenceModel> res = await service.CategorySentenceListAsync();

        foreach (ConceptCategorySentenceModel category in res.Items)
        {
            DataList.Add(category);
        }

    }

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ConceptCategorySentenceModel value = MyUtils.GetValueFromTapped<ConceptCategorySentenceModel>(e);
        ConceptSentencePage.SentenceCat = value;

        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        await MyUtils.NavigateTo(nameof(ConceptSentencePage));
    }
}