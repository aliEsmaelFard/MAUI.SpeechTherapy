using AndroidX.Lifecycle;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using MAUI.SpeechTherapy.Views.Components;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Questions;

public partial class QuestionPage : ContentPage
{
    public ObservableCollection<QuestionModel> DataList { get; set; } = new ObservableCollection<QuestionModel>();
    public static QuestionCategoryModel QuestionCategory { get; set; }

    public string ClickedAnswer { get; set; } = string.Empty;   

    public QuestionPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
        Toolbar.tTittle = QuestionCategory.Name;

     
    }

    bool isCheckRightAnswer = false;
    int CurrentPage = 1;

    private async Task LoadData()
    {
        await SetQuestionBoxData();
    }


    private async Task SetQuestionBoxData()
    {
        try
        {
            ReadInfoDbService service = new ReadInfoDbService();

            DataList.Clear();
            GenericPageByPage<QuestionModel> res = await service.QuestionListAsync(QuestionCategory.Id);

            foreach (QuestionModel item in res.Items)
            {
                DataList.Add(item);
            }

            if (DataList.Count > 0)
            {
                QuestionModel model = DataList[CurrentPage];
                Random random = new Random();

                int rIndex = random.Next(0, 2);
                int wIndex = (rIndex == 1) ? 0 : 1;


                QuestionBox RightQBox = new QuestionBox() { ClassId = "R" };
                QuestionBox WrongQBox = new QuestionBox() { ClassId = "W" };

                (lau_Quetion.Children[rIndex] as QuestionBox).Text = model.RightAnswer;
                (lau_Quetion.Children[rIndex] as QuestionBox).IsRightAnswer = "1";

                (lau_Quetion.Children[wIndex] as QuestionBox).Text = model.WrongAnswer;
                (lau_Quetion.Children[wIndex] as QuestionBox).IsRightAnswer = "0";


                Image.Source = MyUtils.CreateImageSourceFromByte(model.Data);
            }
        }
        catch (Exception ex) { string msg = ex.Message; }
    }




}