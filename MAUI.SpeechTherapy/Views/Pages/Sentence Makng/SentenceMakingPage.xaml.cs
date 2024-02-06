namespace MAUI.SpeechTherapy.Views.Pages.Sentence_Makng;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

public partial class SentenceMakingPage : ContentPage
{

    public string[] fakeData { get; set; } = { "آ", "م", "ز", "ل", "لانل تممابق", "ث" };

    public SentenceMakingPage()
	{
		InitializeComponent();
		BindingContext = this;

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

    
}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}