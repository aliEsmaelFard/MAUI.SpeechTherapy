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
        }
    }
}
