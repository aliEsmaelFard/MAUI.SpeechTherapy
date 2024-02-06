using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Components;

public partial class PaginationCmp : ContentView
{
    public PaginationCmp()
    {
        InitializeComponent();
        PageNumLabel.Text = $"{ PageCount }  /  {CurentPage}";
    }


    public static readonly BindableProperty PageCountProperty =
    BindableProperty.Create(nameof(PageCount), typeof(int), typeof(PaginationCmp), default(int));

    public int PageCount
    {
        get => (int)GetValue(PageCountProperty);
        set => SetValue(PageCountProperty, value);
    } 

    public static readonly BindableProperty CurrentPageProperty =
 BindableProperty.Create(nameof(CurentPage), typeof(int), typeof(PaginationCmp), default(int));

    public int CurentPage
    {
        get => (int)GetValue(CurrentPageProperty);
        set => SetValue(CurrentPageProperty, value);
    }

    public static readonly BindableProperty ForwardCommandProperty =
         BindableProperty.Create(nameof(ForwardCommand), typeof(Action), typeof(PaginationCmp));

    public Action ForwardCommand
    {
        get => (Action)GetValue(ForwardCommandProperty);
        set => SetValue(ForwardCommandProperty, value);
    }

    public static readonly BindableProperty BackWardCommandProperty =
     BindableProperty.Create(nameof(BackWardCommand), typeof(Action), typeof(PaginationCmp));

    public Action BackWardCommand
    {
        get => (Action)GetValue(BackWardCommandProperty);
        set => SetValue(BackWardCommandProperty, value);
    }


    private async void ForwardGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            await ChangeArrowBtnColor(sender);
            ForwardCommand?.Invoke();

        }
        catch (Exception)
        {

        }
    }



    private async void BackwardGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            await ChangeArrowBtnColor(sender);
            BackWardCommand?.Invoke();
        }
        catch (Exception)
        {

        }
    }
    private static async Task ChangeArrowBtnColor(object sender)
    {
        Frame frame = sender as Frame;
        frame.BackgroundColor = Util.GetColorFromResourse("xPrimry");
        await Task.Delay(100);
        frame.BackgroundColor = Colors.White;
    }
}