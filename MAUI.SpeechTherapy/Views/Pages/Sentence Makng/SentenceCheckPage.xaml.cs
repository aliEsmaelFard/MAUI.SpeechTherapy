using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Sentence_Makng;

public partial class SentenceCheckPage : ContentPage
{
	public SentenceCheckPage()
	{
		InitializeComponent();
	}

    private async void beforeItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button btn = sender as Button;
            btn.BackgroundColor = Util.GetColorFromResourse("xButtonColorPressed");
            await Task.Delay(100);
            btn.BackgroundColor = Util.GetColorFromResourse("xButtonColor");


        }
        catch  (Exception ex) { string msg = ex.Message; }
    }

    private void nextItem_Clicked(object sender, EventArgs e)
    {

    }
}