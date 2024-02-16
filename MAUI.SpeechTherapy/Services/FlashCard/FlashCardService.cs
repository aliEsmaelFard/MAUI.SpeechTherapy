using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.FlashCard;

namespace MAUI.SpeechTherapy.Services.FlashCard
{
    public class FlashCardService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<FlashCardModel>> GetPageByPage(int PageSize, int PageNumber,int CategoryId)
        {
            GenericPageByPage<FlashCardModel> Pages = new GenericPageByPage<FlashCardModel>();
            string query = "Select FlashCardModel.Id,Name,Data,FileType" +
               " From FlashCardModel,FileModel" +
               " where FlashCardModel.FileId=FileModel.Id" +
               " and CategoryId=" + CategoryId + " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From FlashCardModel";
            Pages.Items = await db.QueryGetEntityList<FlashCardModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        public async Task<GenericPageByPage<FlashCardModel>> GetPageByPage(int CategoryId)
        {
            GenericPageByPage<FlashCardModel> Pages = new GenericPageByPage<FlashCardModel>();
            string query = "Select FlashCardModel.Id,Name,Data,FileType" +
               " From FlashCardModel,FileModel" +
               " where FlashCardModel.FileId=FileModel.Id" +
               " and CategoryId=" + CategoryId;
            Pages.Items = await db.QueryGetEntityList<FlashCardModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
