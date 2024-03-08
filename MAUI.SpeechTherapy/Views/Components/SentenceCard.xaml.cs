using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Components;

public partial class SentenceCard : ContentView
{
    public SentenceCard()
    {
        InitializeComponent();
        BindingContext = this;


    }


    public static readonly BindableProperty TextProperty =
  BindableProperty.Create(nameof(Text), typeof(string), typeof(SentenceCard), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    public static readonly BindableProperty IsRightAnswerProperty =
BindableProperty.Create(nameof(IsRightAnswer), typeof(string), typeof(SentenceCard), default(string),propertyChanged: ChangeValue);

    public string IsRightAnswer
    {
        get => (string)GetValue(IsRightAnswerProperty);
        set => SetValue(IsRightAnswerProperty, value);
    }

    private static void ChangeValue(BindableObject bindable, object oldValue, object newValue)
    {
        var customComponent = (SentenceCard)bindable;
        string isRight = (string)newValue;

        customComponent.ChangeBoxColors(isRight);

    }

    private void ChangeBoxColors(string isRight)
    {
   if (isRight == "1")
        {
            myBorder.BackgroundColor = MyUtils.GetColorFromResourse("xSentenceRightBG");
            myBorder.Stroke = MyUtils.GetColorFromResourse("xSentenceRightBorder");
        }
        else
        {
            myBorder.BackgroundColor = MyUtils.GetColorFromResourse("xSentenceWrongBG");
            myBorder.Stroke = MyUtils.GetColorFromResourse("xSentenceWrongBorder");
        }
    }
}