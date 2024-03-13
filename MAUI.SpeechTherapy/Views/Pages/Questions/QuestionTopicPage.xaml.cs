using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Questions;

public partial class QuestionTopicPage : ContentPage
{

    public ObservableCollection<QuestionCategoryModel> DataList { get; set; } = new ObservableCollection<QuestionCategoryModel>();
    public QuestionTopicPage()
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
        GenericPageByPage<QuestionCategoryModel> res = await service.QuestionCategoryListAsync();

        foreach (QuestionCategoryModel category in res.Items)
        {
            DataList.Add(category);
        }

    }

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        QuestionCategoryModel value = MyUtils.GetValueFromTapped<QuestionCategoryModel>(e);
        QuestionPage.QuestionCategory = value;

        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        await MyUtils.NavigateTo(nameof(QuestionPage));
    }

}