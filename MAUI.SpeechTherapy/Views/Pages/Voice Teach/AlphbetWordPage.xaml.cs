using Android.Runtime;
using Kotlin.Properties;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetWordPage : ContentPage
{
    public AlphbetWordPage()
    {
        InitializeComponent();
        BindingContext = this;

       
    }

    public ObservableCollection<AlphbaWordModel> DataListFirst { get; set; } = new ObservableCollection<AlphbaWordModel>();
    public ObservableCollection<AlphbaWordModel> DataListMid { get; set; } = new ObservableCollection<AlphbaWordModel>();
    public ObservableCollection<AlphbaWordModel> DataListEnd { get; set; } = new ObservableCollection<AlphbaWordModel>();


    public static AlphbaModel Letter { get; set; }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter.Name;

        await LoadData();

        LabelCharConverter.Letter = Letter.Name[0];
    }

    private async Task LoadData()
    {
        ReadInfoDbService service = new ReadInfoDbService();

        //First
        GenericPageByPage<AlphbaWordModel> res = await service.AlphbaWordListAsync(Letter.Id, 0);
        foreach (AlphbaWordModel model in res.Items)
        {
            DataListFirst.Add(model);
        }

        //Mid
        GenericPageByPage<AlphbaWordModel> resM = await service.AlphbaWordListAsync(Letter.Id, 1);
        foreach (AlphbaWordModel model in resM.Items)
        {
            DataListMid.Add(model);
        }

        //End
        GenericPageByPage<AlphbaWordModel> resE = await service.AlphbaWordListAsync(Letter.Id, 2);
        foreach (AlphbaWordModel model in resE.Items)
        {
            DataListEnd.Add(model);
        }

        myCollection.ItemsSource = DataListFirst;

    }

    //myCollectionView.ItemTemplate = new DataTemplate(() =>
    //{
    //    var label = new Label();
    //    label.SetBinding(Label.TextProperty, new Binding("Text", stringFormat: "<span style='color:black'>{0}</span><span style='color:red'>{1}</span><span style='color:black'>{2}</span>"));
    //    return label;
    //});
    private void TapGestureRecognizer_TappedFirst(object sender, TappedEventArgs e)
    {

        Grid grid = sender as Grid;

        ChangeTapBarColor(grid, true);
        ChangeTapBarColor(tab2, false);
        ChangeTapBarColor(tab3, false);

        myCollection.ItemsSource = DataListFirst;

        //try
        //{
        //    Grid grid = sender as Grid;
        //    string type = MyUtils.GetValueFromTapped<string>(e);
        //    if (type == "First")
        //    {
        //        ChangeTapBarColor(grid, true);
        //        ChangeTapBarColor(tab2  , false);
        //        ChangeTapBarColor(tab3 , false);

        //        myCollection.ItemsSource = DataListFirst;
        //    }
        //    else if (type == "Second")
        //    {
        //        ChangeTapBarColor(grid, true);
        //        ChangeTapBarColor(tab1, false);
        //        ChangeTapBarColor(tab3, false);

        //        myCollection.ItemsSource = DataListMid;
        //    }
        //    else if (type == "Third")
        //    {
        //        ChangeTapBarColor(grid, true);
        //        ChangeTapBarColor(tab2, false);
        //        ChangeTapBarColor(tab1, false);

        //        myCollection.ItemsSource = DataListEnd;
        //    }
        //}
        //catch (Exception ex) { string msg = ex.Message; }

    }


    private void TapGestureRecognizer_TappedMid(object sender, TappedEventArgs e)
    {
        Grid grid = sender as Grid;
        ChangeTapBarColor(grid, true);
        ChangeTapBarColor(tab1, false);
        ChangeTapBarColor(tab3, false);

        myCollection.ItemsSource = DataListMid;
    }

    private void TapGestureRecognizer_TappedEnd(object sender, TappedEventArgs e)
    {
        Grid grid = sender as Grid;
        ChangeTapBarColor(grid, true);
        ChangeTapBarColor(tab2, false);
        ChangeTapBarColor(tab1, false);

        myCollection.ItemsSource = DataListEnd;
    }


    private void ChangeTapBarColor(Grid grid, bool isSelect)
    {
        Label lbl1 = grid.Children[0] as Label;
        BoxView boxView = grid.Children[1] as BoxView;

        if (isSelect)
        {
            lbl1.TextColor = MyUtils.GetColorFromResourse("xPrimry");
            boxView.Color = MyUtils.GetColorFromResourse("xPrimry");
        }
        else
        {
            lbl1.TextColor = MyUtils.GetColorFromResourse("xTabText");
            boxView.Color = Colors.Transparent;
        }
    }

}