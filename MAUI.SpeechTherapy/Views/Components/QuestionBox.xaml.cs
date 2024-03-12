using MAUI.SpeechTherapy.Utils;

namespace MAUI.SpeechTherapy.Views.Components;

public partial class QuestionBox : ContentView
{
	public QuestionBox()
	{
		InitializeComponent();
        BindingContext = this;
	}


    public static readonly BindableProperty TextProperty =
  BindableProperty.Create(nameof(Text), typeof(string), typeof(QuestionBox), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    public static readonly BindableProperty IsRightAnswerProperty =
BindableProperty.Create(nameof(IsRightAnswer), typeof(string), typeof(QuestionBox), default(string));

    public string IsRightAnswer
    {
        get => (string)GetValue(IsRightAnswerProperty);
        set => SetValue(IsRightAnswerProperty, value);
    }

    public static readonly BindableProperty CustomDataProperty = BindableProperty.Create(
        propertyName: "CustomData",
        returnType: typeof(string),
        declaringType: typeof(QuestionBox),
        defaultValue: default(string));

    public string CustomData
    {
        get => (string)GetValue(CustomDataProperty);
        set => SetValue(CustomDataProperty, value);
    }

    private void ChangeBoxColors(string isRight)
    {
        if (isRight == "1")
        {
            myBorder.BackgroundColor = MyUtils.GetColorFromResourse("xSentenceRightBG");
            myBorder.BorderColor = MyUtils.GetColorFromResourse("xSentenceRightBorder");
            box.Source = "rightbox.png";
        }
        else if (isRight == "0") 
        {
            myBorder.BackgroundColor = MyUtils.GetColorFromResourse("xSentenceWrongBG");
            myBorder.BorderColor = MyUtils.GetColorFromResourse("xSentenceWrongBorder");
            box.Source = "wrongbox.png";
        }
        else
        {
            myBorder.BackgroundColor = Colors.White;
            myBorder.BorderColor = Colors.LightGray;
            box.Source = "box.png";
        }
    }

    bool isClicked = false;
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (!isClicked)
        {
            ChangeBoxColors(IsRightAnswer);
            isClicked = true;
        }    
        else
        {
            ChangeBoxColors("NONE");
            isClicked = false;
        }

        if(IsRightAnswer == "1")
        {
            CustomData = "R";
        }
        else if(IsRightAnswer == "0")
        {
            CustomData = "W";
        }
    }


}