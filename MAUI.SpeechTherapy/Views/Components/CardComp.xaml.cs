namespace MAUI.SpeechTherapy.Views.Components;

public partial class CardComp : ContentView
{
	public CardComp()
	{
		InitializeComponent();
        BindingContext = this;
	}

    public static readonly BindableProperty ContentProperty =
         BindableProperty.Create(nameof(Content), typeof(View), typeof(CardComp));

    public View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public static readonly BindableProperty TextProperty =
           BindableProperty.Create(nameof(Text), typeof(string), typeof(CardComp), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty ColorProperty =
         BindableProperty.Create(nameof(ColorP), typeof(Color), typeof(CardComp), default(Color));

    public Color ColorP
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty =
     BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(CardComp), default(string));

    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }


}

