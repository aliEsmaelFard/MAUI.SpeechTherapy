using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using MAUI.SpeechTherapy.Views.Components;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Questions;

public partial class QuestionPage : ContentPage
{
    public ObservableCollection<QuestionModel> DataList { get; set; } = new ObservableCollection<QuestionModel>();
    public static QuestionCategoryModel QuestionCategory { get; set; }
    public QuestionPage()
    {
        InitializeComponent();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
        Title = QuestionCategory.Name;
    }

    int CurrentPage = 1;
    private async Task LoadData()
    {
        ReadInfoDbService service = new ReadInfoDbService();

        DataList.Clear();
        GenericPageByPage<QuestionModel> res = await service.QuestionListAsync(QuestionCategory.Id);
        
        foreach(QuestionModel item in res.Items) 
        {
            DataList.Add(item);
        }
        SetQuestionBoxData();
    }


    private void SetQuestionBoxData()
    {
        try
        {
            if (DataList.Count > 0)
            {
                QuestionModel model = DataList[CurrentPage];
                Random random = new Random();

                int randInt = random.Next(0, 2);
                int secInt = (randInt == 1) ? 0 : 1;

                QuestionBox RightQBox = new QuestionBox();
                QuestionBox WrongQBox = new QuestionBox();
                List<QuestionBox> qList = new List<QuestionBox>() { RightQBox, WrongQBox };

                RightQBox.Text = model.RightAnswer;
                RightQBox.IsRightAnswer = "1";

                WrongQBox.Text = model.WrongAnswer;
                WrongQBox.IsRightAnswer = "0";

                lau_Quetion.Children.Clear();
                lau_Quetion.Add(qList[randInt]);
                lau_Quetion.Add(qList[secInt]);

                Image.Source = MyUtils.CreateImageSourceFromByte(model.Data);
            }
        }
        catch (Exception ex) { string msg = ex.Message; }


    }

}