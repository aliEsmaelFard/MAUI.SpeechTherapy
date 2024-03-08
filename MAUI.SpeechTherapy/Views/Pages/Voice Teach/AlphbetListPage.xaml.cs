using Kotlin.Properties;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Services;
using MAUI.SpeechTherapy.Utils;
using System.Collections.ObjectModel;

namespace MAUI.SpeechTherapy.Views.Pages.Voice_Teach;

public partial class AlphbetListPage : ContentPage
{
	public AlphbetListPage()
	{
		InitializeComponent();
		BindingContext = this;

	}

	public ObservableCollection<AlphbaModel> DataList { get; set; } = new ObservableCollection<AlphbaModel>();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		ReadInfoDbService service = new ReadInfoDbService();

		GenericPageByPage<AlphbaModel> res = await service.AlphbaListAsync();
		foreach (AlphbaModel model in res.Items)
		{
			model.Name = model.Name.Replace("/", "");
			DataList.Add(model);
		}
    }

    private async void ListItemGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        AlphbaModel value = MyUtils.GetValueFromTapped<AlphbaModel>(e);
		AlphbetOptionsPage.Letter = value;

		ContentView contentView = (ContentView)sender ;
		MyUtils.ChangeItemListBackGround(contentView);

		await Shell.Current.GoToAsync(nameof(AlphbetOptionsPage));
    }
}