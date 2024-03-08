using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetSentencePage : ContentPage
{
    public AlphbetSentencePage()
    {
        InitializeComponent();
    }

    public static AlphbaModel Letter { get; set; }

    public string DataText { get; set; } 
    public ImageSource DataImageSource { get; set; }

    GenericPageByPage<AlphbaBookModel> genericList;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Toolbar.tTittle = " صوت " + Letter.Name;

        await LoadData();
    }

    private async Task LoadData()
    {
        try
        {
            ReadInfoDbService service = new ReadInfoDbService();

             genericList = await service.AlphbaBookListAsync(Letter.Id);

            DataText = genericList.Items[0].Text;
            DataImageSource =CreateImageSourceFromByte(genericList.Items[0].Data);

            BindingContext = this;

        }
        catch (Exception ex) { string msg = ex.Message; }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        //Clear From Ram
        DataImageSource = null;
        imageStream.Dispose();
        imageStream = null;
    }

    Stream imageStream;
    public  ImageSource CreateImageSourceFromByte(byte[] bytes)
    {
        imageStream  = new MemoryStream(bytes);
        return ImageSource.FromStream(() => imageStream);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        label.IsVisible = true;
    }

}