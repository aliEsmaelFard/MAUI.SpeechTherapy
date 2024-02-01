namespace MAUI.SpeechTherapy.Views.Components
{

    public partial class HomeCard : ContentView
    {
        public HomeCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty ImageSourceProperty =
       BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(HomeCard), default(string));

        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(HomeCard), default(string));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

       
    }
}
