using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.SentenceMaking;

namespace MAUI.SpeechTherapy.Services.SentenceMaking
{
    public class ObjectService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<ObjectModel>> GetPageByPage(int PageSize, int PageNumber)
        {
            GenericPageByPage<ObjectModel> Pages = new GenericPageByPage<ObjectModel>();
            string query = "Select ObjectModel.Id,Name,Data,FileType" +
               " From ObjectModel,FileModel" +
               " where ObjectModel.FileId=FileModel.Id" +
               " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From ObjectModel";
            Pages.Items = await db.QueryGetEntityList<ObjectModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        public async Task<GenericPageByPage<ObjectModel>> GetPageByPage()
        {
            GenericPageByPage<ObjectModel> Pages = new GenericPageByPage<ObjectModel>();
            string query = "Select ObjectModel.Id,Name,Data,FileType" +
               " From ObjectModel,FileModel" +
               " where ObjectModel.FileId=FileModel.Id";
               
            Pages.Items = await db.QueryGetEntityList<ObjectModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
