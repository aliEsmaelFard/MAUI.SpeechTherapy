using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetWordPage : ContentPage
{
    public AlphbetWordPage()
    {
        InitializeComponent();
        BindingContext = this;

       
    }

    public string[] fakeData1 { get; set; } = { "یاشسآ", "مشسی", "زشسیب", "شسیبل", "سیق", "شسث" };
    public string[] fakeData2 { get; set; } = { "یاخخخشسآ", "مرذرشسی", "زشسصثقیب", "ششل", "بش", "لایب" };
    public string[] fakeData3 { get; set; } = { "یاشبلبآ", "مشسنمنی", "صصص", "صصص", "سصصصیق", "شسصصث" };

    public static string Letter { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter;

        myCollection.ItemsSource = fakeData1;
    }
     //myCollectionView.ItemTemplate = new DataTemplate(() =>
        //{
        //    var label = new Label();
        //    label.SetBinding(Label.TextProperty, new Binding("Text", stringFormat: "<span style='color:black'>{0}</span><span style='color:red'>{1}</span><span style='color:black'>{2}</span>"));
        //    return label;
        //});
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            Grid grid = sender as Grid;
            string type = Util.GetValueFromTapped<string>(e);
            if (type == "First")
            {
                ChangeTapBarColor(grid, true);
                ChangeTapBarColor(tab2  , false);
                ChangeTapBarColor(tab3 , false);

                myCollection.ItemsSource = fakeData1;
            }
            else if (type == "Second")
            {
                ChangeTapBarColor(grid, true);
                ChangeTapBarColor(tab1, false);
                ChangeTapBarColor(tab3, false);

                myCollection.ItemsSource = fakeData2;
            }
            else if (type == "Third")
            {
                ChangeTapBarColor(grid, true);
                ChangeTapBarColor(tab2, false);
                ChangeTapBarColor(tab1, false);

                myCollection.ItemsSource = fakeData3;
            }
        }
        catch (Exception ex) { string msg = ex.Message; }

    }

    private void ChangeTapBarColor(Grid grid, bool isSelect)
    {
        Label lbl1 = grid.Children[0] as Label;
        BoxView boxView = grid.Children[1] as BoxView;

        if (isSelect)
        {
            lbl1.TextColor = Util.GetColorFromResourse("xPrimry");
            boxView.Color = Util.GetColorFromResourse("xPrimry");
        }
        else
        {
            lbl1.TextColor = Util.GetColorFromResourse("xTabText");
            boxView.Color = Colors.Transparent;
        }
    }
}