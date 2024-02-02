namespace MAUI.SpeechTherapy.Views.Components;

public partial class ToolBarContent : ContentView
{
	public ToolBarContent()
	{
		InitializeComponent();
        BindingContext = this;
	}

    public static readonly BindableProperty TollBarTittleProperty =
        BindableProperty.Create(nameof(tTittle), typeof(string), typeof(ToolBarContent), default(string));

    public string tTittle
    {
        get => (string)GetValue(TollBarTittleProperty);
        set => SetValue(TollBarTittleProperty, value);
    }

}