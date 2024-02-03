namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetWordPage : ContentPage
{
	public AlphbetWordPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    public string[] fakeData { get; set; } = { "یاشسآ", "مشسی", "زشسیب", "شسیبل", "سیق", "شسث" };

    public static string Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter;

        //myCollectionView.ItemTemplate = new DataTemplate(() =>
        //{
        //    var label = new Label();
        //    label.SetBinding(Label.TextProperty, new Binding("Text", stringFormat: "<span style='color:black'>{0}</span><span style='color:red'>{1}</span><span style='color:black'>{2}</span>"));
        //    return label;
        //});

    }

}