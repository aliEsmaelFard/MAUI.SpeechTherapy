using CommunityToolkit.Maui.Alerts;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Concept;
using MAUI.SpeechTherapy.Services;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Comprehension;

public partial class ConceptSentencePage : ContentPage
{

    public ConceptSentencePage()
    {
        InitializeComponent();
        BindingContext = this;

    }


    public ObservableCollection<ConceptSentenceModel> DataList { get; set; } = new ObservableCollection<ConceptSentenceModel>();

    public static ConceptCategorySentenceModel SentenceCat { get; set; }
    public string DataText { get; set; }
    public ImageSource DataImageSource { get; set; }



    protected async override void OnAppearing()
    {
        base.OnAppearing();
        base.OnAppearing();
        await LoadData();
        Toolbar.tTittle = SentenceCat.Name;

        PaginCmp.ForwardCommand += ForwardWardClick;
        PaginCmp.BackWardCommand += BackWardClick;

    }

    int CurrentPage = 1;
    private async Task LoadData()
    {
        try
        {
            ReadInfoDbService service = new ReadInfoDbService();

            DataList.Clear();
            GenericPageByPage<ConceptSentenceModel> res = await service.ConceptSentenceListAsync(SentenceCat.Id);

            DataList.Clear();
            foreach (ConceptSentenceModel item in res.Items)
            {
                DataList.Add(item);
            }


            PaginCmp.PageCount = DataList.Count;
            PaginCmp.CurentPage = CurrentPage;

            ReSetViewData();

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }


    private void ReSetViewData()
    {
        if (DataList.Count > 0)
        {
            label.IsVisible = false;
            label.Text =  DataList[CurrentPage - 1].Text;
            Image.Source = CreateImageSourceFromByte(DataList[CurrentPage - 1].Data);

        }
    }

    private async void BackWardClick()
    {

        if (CurrentPage > 1)
        {
            CurrentPage--;
            PaginCmp.CurentPage = CurrentPage;
            ReSetViewData(); 
        }
    }


    private async void ForwardWardClick()
    {
        if (!label.IsVisible)
        {
            await Snackbar.Make("أولا، راجع النص", actionButtonText: "").Show();
            return;
        }

        if (CurrentPage < DataList.Count)
        {
            CurrentPage++;
            PaginCmp.CurentPage = CurrentPage;
            ReSetViewData();
        }
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
    public ImageSource CreateImageSourceFromByte(byte[] bytes)
    {
        imageStream = new MemoryStream(bytes);
        return ImageSource.FromStream(() => imageStream);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        label.IsVisible = true;
    }


}