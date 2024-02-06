using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Components;

public partial class SentenceCard : ContentView
{
	public SentenceCard()
	{
		InitializeComponent();
        BindingContext = this;

        bool x = (bool)GetValue(IsRightAnswerProperty);
	}


    public static readonly BindableProperty TextProperty =
  BindableProperty.Create(nameof(Text), typeof(string), typeof(SentenceCard), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    public static readonly BindableProperty IsRightAnswerProperty =
BindableProperty.Create(nameof(IsRightAnswer), typeof(bool), typeof(SentenceCard), default(bool));

    public bool IsRightAnswer
    {
        get => (bool)GetValue(IsRightAnswerProperty);
        set
        {
             SetValue(IsRightAnswerProperty, value);

            if (value)
            {
                myBorder.BackgroundColor = Util.GetColorFromResourse("xSentenceRightBG");
                myBorder.Stroke = Util.GetColorFromResourse("xSentenceRightBorder");
            }
            else
            {
                myBorder.BackgroundColor = Util.GetColorFromResourse("xSentenceWrongBG");
                myBorder.Stroke = Util.GetColorFromResourse("xSentenceWrongBorder");
            }
        }
    }


}