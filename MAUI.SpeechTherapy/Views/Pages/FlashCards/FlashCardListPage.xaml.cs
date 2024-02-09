
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.FlashCards;

public partial class FlashCardListPage : ContentPage
{
    public FlashCardListPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public static string Topic { set; get; }

    public ObservableCollection<TestModel> list { set; get; } = new ObservableCollection<TestModel>();
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = Topic;

        list.Add(new TestModel { Name = "کلمه", Path = "flash1" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash2" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash3" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash1" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash2" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash3" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash1" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash2" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash3" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash1" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash2" });
        list.Add(new TestModel { Name = "کلمه", Path = "flash3" });

    }
    public TestModel testModel { get; set; }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
    //    Border border = sender as Border;
    //    Grid grid = border.GetVisualTreeDescendants().
    //                Where(x => x.GetType() == typeof(Grid)).First() as Grid;

        Grid grid = sender as Grid;
        Image image = grid.Children[0] as Image;
        image.IsVisible = !image.IsVisible;
    }
}