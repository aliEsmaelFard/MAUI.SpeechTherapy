using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Models.Question;

namespace MAUI.SpeechTherapy.Services.Question
{
    public class QuestionService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<QuestionModel>> GetPageByPage(int PageSize, int PageNumber)
        {
            GenericPageByPage<QuestionModel> Pages = new GenericPageByPage<QuestionModel>();
            string query = "Select QuestionModel.Id,RightAnswer,WrongAnswer,Data,FileType" +
               " From QuestionModel,FileModel" +
               " where QuestionModel.FileId=FileModel.Id" +
               "  LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From FlashCardModel";
            Pages.Items = await db.QueryGetEntityList<QuestionModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        public async Task<GenericPageByPage<QuestionModel>> GetPageByPage()
        {
            GenericPageByPage<QuestionModel> Pages = new GenericPageByPage<QuestionModel>();
            string query = "Select QuestionModel.Id,RightAnswer,WrongAnswer,Data,FileType" +
               " From QuestionModel,FileModel" +
               " where QuestionModel.FileId=FileModel.Id";
               
            Pages.Items = await db.QueryGetEntityList<QuestionModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
