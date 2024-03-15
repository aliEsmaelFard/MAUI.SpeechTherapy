using CommunityToolkit.Maui.Alerts;
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

    public string ClickedAnswer { get; set; }

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

        PaginCmp.ForwardCommand += ForwardWardClick;
        PaginCmp.BackWardCommand += BackWardClick;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

    }

    int CurrentPage = 1;
    private async Task LoadData()
    {
        ReadInfoDbService service = new ReadInfoDbService();

        DataList.Clear();
        GenericPageByPage<QuestionModel> res = await service.QuestionListAsync(QuestionCategory.Id);
        foreach (QuestionModel item in res.Items)
        {
            DataList.Add(item);
        }

        PaginCmp.PageCount = DataList.Count;
        PaginCmp.CurentPage = CurrentPage;
        await SetQuestionBoxData();
    }


    public async Task SetQuestionBoxData()
    {
        try
        {
            if (DataList.Count > 0)
            {
                //clear question box clicked
                q_FirstQ.CustomData = null;
                q_SececndQ.CustomData = null;

                QuestionModel model = DataList[CurrentPage - 1];
                Random random = new Random();

                int rIndex = random.Next(0, 2);
                int wIndex = (rIndex == 1) ? 0 : 1;

                (lau_Quetion.Children[rIndex] as QuestionBox).BeReset = "Change" +random.Next(100);
                (lau_Quetion.Children[rIndex] as QuestionBox).Text = model.RightAnswer;
                (lau_Quetion.Children[rIndex] as QuestionBox).IsRightAnswer = "1";

                (lau_Quetion.Children[wIndex] as QuestionBox).BeReset = "Change" + random.Next(100);
                (lau_Quetion.Children[wIndex] as QuestionBox).Text = model.WrongAnswer;
                (lau_Quetion.Children[wIndex] as QuestionBox).IsRightAnswer = "0";

                Image.Source = MyUtils.CreateImageSourceFromByte(model.Data);


            }
        }
        catch (Exception ex) { string msg = ex.Message; }
    }


    private async void BackWardClick()
    {
        /*
        if (string.IsNullOrEmpty(q_FirstQ.CustomData) && string.IsNullOrEmpty(q_SececndQ.CustomData))
        {
            await Snackbar.Make("الرجاء الإجابة على السؤال.", actionButtonText: "").Show();

            return;
        }
        */
        if (CurrentPage > 1)
        {
            CurrentPage--;
            PaginCmp.CurentPage = CurrentPage;
            await SetQuestionBoxData();
        }
    }


    private async void ForwardWardClick()
    {
        if (string.IsNullOrEmpty(q_FirstQ.CustomData) && string.IsNullOrEmpty(q_SececndQ.CustomData))
        {
            await Snackbar.Make("الرجاء الإجابة على السؤال.", actionButtonText: "").Show();

            return;
        }


        if (CurrentPage < DataList.Count)
        {
            CurrentPage++;
            PaginCmp.CurentPage = CurrentPage;
            await SetQuestionBoxData();
        }
    }
}