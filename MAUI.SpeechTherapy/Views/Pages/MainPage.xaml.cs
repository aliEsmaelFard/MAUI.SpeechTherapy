using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Models.Concept;
using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Models.SentenceMaking;
using MAUI.SpeechTherapy.Services;


namespace MAUI.SpeechTherapy
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
           

            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ReadInfoDbService  dbService = new ReadInfoDbService();
            
            GenericPageByPage<ObjectModel> d = await dbService.ObjectListAsync();
            GenericPageByPage<ConceptSentenceModel> d1 =await dbService.ConceptSentenceListAsync(d.Items[0].Id,1,2);
            GenericPageByPage<ConceptQuestionModel> d2 =await dbService.ConceptQuestionListAsync(d.Items[0].Id,1,2);
            GenericPageByPage<AlphbaBookModel> d3 =await dbService.AlphbaBookListAsync(d.Items[0].Id,1,2);
            GenericPageByPage<AlphbaWordModel> d4 =await dbService.AlphbaWordListAsync(d.Items[0].Id,1);
            GenericPageByPage<AlphbaModel> d5 =await dbService.AlphbaListAsync();
            GenericPageByPage<FlashCardCategory> d6 =await dbService.FlashCardCategoryListAsync(1,2);
            GenericPageByPage<FlashCardModel> d7 =await dbService.FlashCardListAsync(d.Items[0].Id,1,2);
            GenericPageByPage<QuestionModel> d8 =await dbService.QuestionListAsync(d.Items[0].Id,1,2);
            GenericPageByPage<SubjectModel> d9 =await dbService.SubjectListAsync();
            GenericPageByPage<VerbModel> d10 =await dbService.VerbListAsync();
            GenericPageByPage<SentenceMakingModel> d11 =await dbService.SentenceMakingListAsync(1,2);
            
        }
    }

}
