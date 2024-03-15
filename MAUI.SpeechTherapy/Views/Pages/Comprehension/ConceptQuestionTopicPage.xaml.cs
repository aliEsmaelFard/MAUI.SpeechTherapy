using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Concept;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Comprehension;

public partial class ConceptQuestionTopicPage : ContentPage
{

    public ObservableCollection<ConceptCategoryQuestionModel> DataList { get; set; } = new ObservableCollection<ConceptCategoryQuestionModel>();
    public ConceptQuestionTopicPage()
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
        GenericPageByPage<ConceptCategoryQuestionModel> res = await service.CategoryQuestionListAsync();

        foreach (ConceptCategoryQuestionModel category in res.Items)
        {
            DataList.Add(category);
        }

    }

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ConceptCategoryQuestionModel value = MyUtils.GetValueFromTapped<ConceptCategoryQuestionModel>(e);
        ConceptQuestionPage.QuestionCat = value;

        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        await MyUtils.NavigateTo(nameof(ConceptQuestionPage));
    }
}