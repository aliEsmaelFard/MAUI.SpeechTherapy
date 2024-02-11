namespace MAUI.SpeechTherapy.Views.Pages.Comprehension;
#if ANDROID
using Android.Content;


using Android.Provider;


#endif
public partial class ComprehensionTopicPage : ContentPage
{
	public ComprehensionTopicPage()
	{
		InitializeComponent();

        Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
               handler.PlatformView.Settings.JavaScriptEnabled=true;
                handler.PlatformView.Settings.AllowFileAccess = true;
                handler.PlatformView.Settings.AllowFileAccessFromFileURLs = true;
                handler.PlatformView.Settings.AllowUniversalAccessFromFileURLs = true;

#endif
        });
    }
}