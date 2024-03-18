using MAUI.SpeechTherapy.Models.SentenceMaking;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Sentence_Makng;

public partial class SentenceCheckPage : ContentPage
{
    public static SentenceMakingModel RightSentence;
    public static SentenceMakingModel AnswerSentence;

    public SentenceCheckPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            await LoadData();

            if(SentenceMakingPage.CurrentPage == 1)
               btn_beforeItem.IsVisible = false;
            if(SentenceMakingPage.CurrentPage == SentenceMakingPage.PageNumber) 
                btn_nextItem.IsVisible = false; 
        }
        catch (Exception ex)
        {

        }
    }

    private async Task LoadData()
    {
        try
        {
            SetImageData();
            SetCardText();
            SetDescriptionText();
            label_pag.Text = $"البند {SentenceMakingPage.CurrentPage} من {SentenceMakingPage.PageNumber}";

        }
        catch (Exception ex)
        {

        }
    }

    private void SetDescriptionText()
    {
        string TitelText = "خطأ";
        string CaptionText = "";

        // 1- all right
        if (
            AnswerSentence.ObjectId == RightSentence.ObjectId
            && AnswerSentence.VerbId == RightSentence.VerbId
            && AnswerSentence.SubjectId == RightSentence.SubjectId
            )
        {
            TitelText = "أحسنت، لقد أجبت بشكل صحيح.";
            CaptionText = "";
        }
        //2- all wrong
        else if (
            AnswerSentence.ObjectId != RightSentence.ObjectId
            && AnswerSentence.VerbId != RightSentence.VerbId
            && AnswerSentence.SubjectId != RightSentence.SubjectId
            )
        {
            TitelText = "حاول مرة أخرى";
            CaptionText = "";
        }
        //3- Fel & Fael wrong
        else if (
            AnswerSentence.ObjectId == RightSentence.ObjectId
            && AnswerSentence.VerbId != RightSentence.VerbId
            && AnswerSentence.SubjectId != RightSentence.SubjectId
            )
        {
            TitelText = "خطأ في الفاعل و الفعل ";
            CaptionText = "";
        }

        //4-Mafol & Fael wrong
        else if (
            AnswerSentence.ObjectId != RightSentence.ObjectId
            && AnswerSentence.VerbId == RightSentence.VerbId
            && AnswerSentence.SubjectId != RightSentence.SubjectId
            )
        {
            TitelText = "خطأ في الفاعل و المفعول به";
            CaptionText = "";
        }
        //5-Fel & Mafol wrong
        else if (
            AnswerSentence.ObjectId != RightSentence.ObjectId
            && AnswerSentence.VerbId != RightSentence.VerbId
            && AnswerSentence.SubjectId == RightSentence.SubjectId
            )
        {
            TitelText = "خطأ في  الفعل والمفعول به";
            CaptionText = "";
        }
        //6- Fel  wrong
        else if (
            AnswerSentence.ObjectId == RightSentence.ObjectId
            && AnswerSentence.VerbId != RightSentence.VerbId
            && AnswerSentence.SubjectId == RightSentence.SubjectId
            )
        {
            TitelText = "خطأ في  الفعل ";
            CaptionText = "";
        }
        //7-  mafol wrong
        else if (
            AnswerSentence.ObjectId != RightSentence.ObjectId
            && AnswerSentence.VerbId == RightSentence.VerbId
            && AnswerSentence.SubjectId == RightSentence.SubjectId
            )
        {
            TitelText = "خطأ في المفعول به";
            CaptionText = "";
        }
        //8- Fael wrong
        else if (
            AnswerSentence.ObjectId == RightSentence.ObjectId
            && AnswerSentence.VerbId == RightSentence.VerbId
            && AnswerSentence.SubjectId != RightSentence.SubjectId
            )
        {
            TitelText = "خطأ في الفاعل";
            CaptionText = "";
        }
        label_desTitel.Text = TitelText;
        label_desCaption.Text = CaptionText;

    }
    private async void SetCardText()
    {
        try
        {
            if (AnswerSentence != null)
            {
                ReadInfoDbService service = new ReadInfoDbService();

                label_sub.Text = (await service.GetEntityById<SubjectModel>(AnswerSentence.SubjectId)).Name;
                if (RightSentence.SubjectId != AnswerSentence.SubjectId)
                    label_sub.IsRightAnswer = "0";

                label_obj.Text = (await service.GetEntityById<ObjectModel>(AnswerSentence.ObjectId)).Name;
                if (RightSentence.ObjectId != AnswerSentence.ObjectId)
                    label_obj.IsRightAnswer = "0";

                label_vrb.Text = (await service.GetEntityById<VerbModel>(AnswerSentence.VerbId)).Name;
                if (RightSentence.VerbId != AnswerSentence.VerbId)
                    label_vrb.IsRightAnswer = "0";


            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    private void SetImageData()
    {
        try
        {
            if (RightSentence != null)
            {
                objectImg.Source = CreateImageSourceFromByte(RightSentence.ObjectData);
                verbImg.Source = CreateImageSourceFromByte(RightSentence.VerbData);
                subjectImg.Source = CreateImageSourceFromByte(RightSentence.SubjectData);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }

    private async void beforeItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button btn = sender as Button;
            btn.BackgroundColor = MyUtils.GetColorFromResourse("xButtonColorPressed");
            await Task.Delay(100);
            btn.BackgroundColor = MyUtils.GetColorFromResourse("xButtonColor");

            SentenceMakingPage.CurrentPage--;
          //  await MyUtils.NavigateTo(nameof(SentenceMakingPage));
          await Navigation.PopAsync();
        }
        catch (Exception ex) { string msg = ex.Message; }
    }

    private async void nextItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button btn = sender as Button;
            btn.BackgroundColor = MyUtils.GetColorFromResourse("xButtonColorPressed");
            await Task.Delay(100);
            btn.BackgroundColor = Colors.White;

            SentenceMakingPage.CurrentPage++;
            //await MyUtils.NavigateTo(nameof(SentenceMakingPage));
            await Navigation.PopAsync();

        }
        catch (Exception ex) { string msg = ex.Message; }
    }


    public ImageSource CreateImageSourceFromByte(byte[] bytes)
    {
        try
        {
            Stream imageStream;

            imageStream = new MemoryStream(bytes);
            return ImageSource.FromStream(() => imageStream);
        }
        catch (Exception ex)
        {
        }
        return null;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        //Clear From Ram
        //imageStream.Dispose();
        //imageStream = null;
    }
}