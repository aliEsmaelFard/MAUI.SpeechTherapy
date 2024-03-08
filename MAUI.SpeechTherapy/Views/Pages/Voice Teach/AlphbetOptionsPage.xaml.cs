using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetOptionsPage : ContentPage
{

	public AlphbetOptionsPage()
	{
		InitializeComponent();
       
	}

    public static AlphbaModel Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter.Name;
        VideoItem.Text = $"تعليم صوت {Letter.Name} منفردا";
        WordItem.Text = $"تعليم صوت {Letter.Name} في الكلمة";
        SentenceItem.Text = $"تعليم صوت {Letter.Name} في الجملة";
    }
    private async void VideoGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        AlphbetVideoPage.Letter = Letter;
        await Shell.Current.GoToAsync(nameof(AlphbetVideoPage));
    }

    private async void WordGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        AlphbetWordPage.Letter = Letter;
        await Shell.Current.GoToAsync(nameof(AlphbetWordPage));
    }

    private async void SentenceGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ContentView contentView = (ContentView)sender;
        MyUtils.ChangeItemListBackGround(contentView);

        AlphbetSentencePage.Letter = Letter;
        await Shell.Current.GoToAsync(nameof(AlphbetSentencePage));
    }


}