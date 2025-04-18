﻿using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Pages.Sentence_Makng;

using CommunityToolkit.Maui.Alerts;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.SentenceMaking;
using MAUI.SpeechTherapy.Services;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

public partial class SentenceMakingPage : ContentPage
{

    public static int CurrentPage { get; set; } = 1;
    public static int PageNumber { get; set; }

    SentenceMakingModel sentence;

    public SentenceMakingPage()
    {
        InitializeComponent();
        BindingContext = this;

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

    }

    ReadInfoDbService service = new ReadInfoDbService();
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        label.Text = "الصورة الأولى هي الفاعل و الصورة الثانية مرتبطة بالفعل و الصورة الثالثة مرتبطة بالمفعول. حدد الفاعل و الفعل و المفعول المناسب حسب الصورة. و اضغط على زر \"الفحص\" لتكون الجملة صحيحة حسب القواعد.";
        await LoadData();
        //this.OnBackButtonPressed += SentenceMakingPage_BackButtonPressed;
    }

    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            await MyUtils.NavigateTo(nameof(MainPage));
        });
        CurrentPage = 1;
        return true;
    }

    private async Task LoadData()
    {
        try
        {
            GenericPageByPage<SentenceMakingModel> genericList = await service.SentenceMakingListAsync();

            if (genericList.Items.Count > 0)
            {
                sentence = genericList.Items[CurrentPage - 1];
                PageNumber = genericList.RowCount;
                label_pag.Text = $"البند {CurrentPage} من {PageNumber}";
                SetImageData();
                SetPickerData();
            }

        }
        catch (Exception ex)
        {

        }


    }

    private async void SetPickerData()
    {
        try
        {
            objectPicker.ItemsSource = (await service.ObjectListAsync()).Items;
            objectPicker.ItemDisplayBinding = new Binding("Name");

            subjectPicker.ItemsSource = (await service.SubjectListAsync()).Items;
            subjectPicker.ItemDisplayBinding = new Binding("Name");

            verbPicker.ItemsSource = (await service.VerbListAsync()).Items;
            verbPicker.ItemDisplayBinding = new Binding("Name");

            /*
             var objList = (await service.ObjectListAsync()).Items;
            objectPicker.ItemsSource = objList.Select(x=> x.Name).ToList();
            subjectPicker.ItemsSource = (await service.SubjectListAsync()).Items.Select(x => x.Name).ToList();
            verbPicker.ItemsSource = (await service.VerbListAsync()).Items.Select(x => x.Name).ToList();
             */
        }
        catch (Exception ex)
        {

        }

    }

    private void SetImageData()
    {
        try
        {
            if (sentence != null)
            {
                objectImg.Source = CreateImageSourceFromByte(sentence.ObjectData);
                verbImg.Source = CreateImageSourceFromByte(sentence.VerbData);
                subjectImg.Source = CreateImageSourceFromByte(sentence.SubjectData);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }


    public ImageSource CreateImageSourceFromByte(byte[] bytes)
    {
        Stream imageStream;
        imageStream = new MemoryStream(bytes);
        return ImageSource.FromStream(() => imageStream);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (objectPicker.SelectedIndex == -1 || verbPicker.SelectedIndex == -1 || subjectPicker.SelectedIndex == -1)
        {
            await Snackbar.Make("أولا، حدد كافة الخيارات ذات الصلة.", actionButtonText: "").Show();
            return;
        }

        SentenceMakingModel sentenceMaking = new SentenceMakingModel()
        {
            ObjectId = (objectPicker.SelectedItem as ObjectModel).Id,
            SubjectId = (subjectPicker.SelectedItem as SubjectModel).Id,
            VerbId = (verbPicker.SelectedItem as VerbModel).Id,
        };

        SentenceCheckPage.RightSentence = sentence;
        SentenceCheckPage.AnswerSentence = sentenceMaking;

        await MyUtils.NavigateTo(nameof(SentenceCheckPage));
    }


}