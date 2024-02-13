using MAUI.SpeechTherapy.Views.Pages.AboutUs;
using MAUI.SpeechTherapy.Views.Pages.Comprehension;
using MAUI.SpeechTherapy.Views.Pages.FlashCards;
using MAUI.SpeechTherapy.Views.Pages.Questions;
using MAUI.SpeechTherapy.Views.Pages.Sentence_Makng;
using MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

namespace MAUI.SpeechTherapy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AlphbetListPage) , typeof(AlphbetListPage));
            Routing.RegisterRoute(nameof(AlphbetOptionsPage) , typeof(AlphbetOptionsPage));
            Routing.RegisterRoute(nameof(AlphbetVideoPage) , typeof(AlphbetVideoPage));
            Routing.RegisterRoute(nameof(AlphbetWordPage) , typeof(AlphbetWordPage));
            Routing.RegisterRoute(nameof(AlphbetSentencePage) , typeof(AlphbetSentencePage));
            
            
            Routing.RegisterRoute(nameof(SentenceMakingPage) , typeof(SentenceMakingPage));
            Routing.RegisterRoute(nameof(SentenceCheckPage) , typeof(SentenceCheckPage));

            Routing.RegisterRoute(nameof(FlashCardListPage) , typeof(FlashCardListPage));
            Routing.RegisterRoute(nameof(FlashCardsTopicPage), typeof(FlashCardsTopicPage));
          
            Routing.RegisterRoute(nameof(ComprehensionTopicPage), typeof(ComprehensionTopicPage));
            
            Routing.RegisterRoute(nameof(QuestionPage), typeof(QuestionPage));
          
            Routing.RegisterRoute(nameof(AboutUsHubPage), typeof(AboutUsHubPage));
            Routing.RegisterRoute(nameof(AboutAuthorPage), typeof(AboutAuthorPage));
            Routing.RegisterRoute(nameof(AboutProgrammerPage), typeof(AboutProgrammerPage));

        }
    }
}
