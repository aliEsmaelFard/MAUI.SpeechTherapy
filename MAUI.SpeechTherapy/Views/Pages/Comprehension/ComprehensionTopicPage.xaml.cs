using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Comprehension;

public partial class ComprehensionTopicPage : ContentPage
{
    public ComprehensionTopicPage()
    {
        InitializeComponent();

        Toolbar.tTittle = "فهم الاسئلة ";
    }

    private async void QuestionSectionTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await MyUtils.NavigateTo(nameof(ConceptQuestionTopicPage));
    }

    private async void BookSectionTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await MyUtils.NavigateTo(nameof(ConceptSentenceTopicPage));
    }
}