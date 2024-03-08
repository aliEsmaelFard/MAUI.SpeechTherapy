
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MAUI.SpeechTherapy.Views.Pages.FlashCards;

public partial class FlashCardListPage : ContentPage
{
    public FlashCardListPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public static FlashCardCategory FlashCardsTopic { set; get; }

    public ObservableCollection<FlashCardModel> DataList { set; get; } = new ObservableCollection<FlashCardModel>();
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = FlashCardsTopic.Name;

        
        await LoadData();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        DataList.Clear();
    }
    private async Task LoadData()
    {
        ReadInfoDbService service = new ReadInfoDbService();

        GenericPageByPage<FlashCardModel> res = await service.FlashCardListAsync(FlashCardsTopic.Id);

        DataList.Clear();
        foreach (FlashCardModel category in res.Items)
        {
            category.Source = MyUtils.CreateImageSourceFromByte(category.Data);
            category.Color = SetCardColor();
            category.NameEN = ExtractWordInParentheses(category.Name);
            category.NameAB = RemoveParentheses(category.Name);
            
            DataList.Add(category);
        }

    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        //    Border border = sender as Border;
        //    Grid grid = border.GetVisualTreeDescendants().
        //                Where(x => x.GetType() == typeof(Grid)).First() as Grid;

        Grid grid = sender as Grid;
        Image image = grid.Children[0] as Image;
        image.IsVisible = !image.IsVisible;
    }

    public static string RemoveParentheses(string input)
    {
        int startIndex = input.IndexOf('(');
        int endIndex = input.IndexOf(')');

        if (startIndex >= 0 && endIndex >= 0 && endIndex > startIndex)
        {
            string contentToRemove = input.Substring(startIndex, endIndex - startIndex + 1);
            input = input.Replace(contentToRemove, "");
        }

        return input.Trim();
    }


    public static string ExtractWordInParentheses(string input)
    {
        // Extract word inside parentheses
        string wordPattern = @"\(([^)]*)\)";
        string wordInParentheses = Regex.Match(input, wordPattern).Groups[1].Value;

       
        return wordInParentheses;
    }

    private Color SetCardColor()
    {
        Color color = new Color();
        switch (FlashCardsTopic.Id)
        {
            //مجموعة الحیوانات
            case 2: { color = MyUtils.GetColorFromResourse("xAnimal"); } break;
            //مجموعة الفواکه
            case 3: { color = MyUtils.GetColorFromResourse("xFood"); } break;
            //مجموعة الأفعال
            case 4: { color = MyUtils.GetColorFromResourse("xVerb"); } break;
            //مجموعة الأطعمة
            case 5: { color = MyUtils.GetColorFromResourse("xFood"); } break;
            //مجموعة الاثاث
            case 6: { color = MyUtils.GetColorFromResourse("xObject"); } break;
            //مجموعة المکسرات
            case 7: { color = MyUtils.GetColorFromResourse("xNuts"); } break;
            //مجموعة الخضروات
            case 8: { color = MyUtils.GetColorFromResourse("xVegtebel"); } break;
            //مجموعة الملابس
            case 9: { color = MyUtils.GetColorFromResourse("xCloth"); } break;
            //مجموعة وسائل النقل
            case 10: { color = MyUtils.GetColorFromResourse("xTransfer"); } break;
        }
        return color;
    }

}