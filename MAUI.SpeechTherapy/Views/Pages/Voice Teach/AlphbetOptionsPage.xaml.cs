using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetOptionsPage : ContentPage
{

	public AlphbetOptionsPage()
	{
		InitializeComponent();
       
	}

    public static string Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter;
        VideoItem.Text = $"تعليم صوت {Letter} منفردا";
        WordItem.Text = $"تعليم صوت {Letter} في الكلمة";
        SentenceItem.Text = $"تعليم صوت {Letter} في الجملة";
    }
    private async void VideoGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ContentView contentView = (ContentView)sender;
        Util.ChangeItemListBackGround(contentView);

        AlphbetVideoPage.Letter = Letter;
        await Shell.Current.GoToAsync(nameof(AlphbetVideoPage));
    }

    private async void WordGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ContentView contentView = (ContentView)sender;
        Util.ChangeItemListBackGround(contentView);

        AlphbetWordPage.Letter = Letter;
        await Shell.Current.GoToAsync(nameof(AlphbetWordPage));
    }

    private void SentenceGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ContentView contentView = (ContentView)sender;
        Util.ChangeItemListBackGround(contentView);

    }


}