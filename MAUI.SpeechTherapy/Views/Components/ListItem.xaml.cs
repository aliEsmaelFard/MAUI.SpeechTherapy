namespace MAUI.SpeechTherapy.Views.Components;

public partial class ListItem : ContentView
{
	public ListItem()
	{
		InitializeComponent();
        BindingContext = this;
    }

    public static readonly BindableProperty TextProperty =
       BindableProperty.Create(nameof(Text), typeof(string), typeof(ListItem), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

}