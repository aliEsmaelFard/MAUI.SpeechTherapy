using MAUI.SpeechTherapy.Models.SentenceMaking;
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

        await LoadData();
    }

    private async Task LoadData()
    {
        SetImageData();
    }


    private async void beforeItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button btn = sender as Button;
            btn.BackgroundColor = MyUtils.GetColorFromResourse("xButtonColorPressed");
            await Task.Delay(100);
            btn.BackgroundColor = MyUtils.GetColorFromResourse("xButtonColor");
        }
        catch (Exception ex) { string msg = ex.Message; }
    }

    private void nextItem_Clicked(object sender, EventArgs e)
    {

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

    Stream imageStream;
    public ImageSource CreateImageSourceFromByte(byte[] bytes)
    {
        try
        {
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
        imageStream.Dispose();
        imageStream = null;
    }
}