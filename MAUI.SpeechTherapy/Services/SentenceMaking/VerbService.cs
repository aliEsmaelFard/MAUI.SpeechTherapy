using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.SentenceMaking;

namespace MAUI.SpeechTherapy.Services.SentenceMaking
{
    public class VerbService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<VerbModel>> GetPageByPage(int PageSize, int PageNumber)
        {
            GenericPageByPage<VerbModel> Pages = new GenericPageByPage<VerbModel>();
            string query = "Select VerbModel.Id,Name,Data,FileType" +
               " From VerbModel,FileModel" +
               " where VerbModel.FileId=FileModel.Id" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From VerbModel";
            Pages.Items = await db.QueryGetEntityList<VerbModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        public async Task<GenericPageByPage<VerbModel>> GetPageByPage()
        {
            GenericPageByPage<VerbModel> Pages = new GenericPageByPage<VerbModel>();
            string query = "Select VerbModel.Id,Name,Data,FileType" +
               " From VerbModel,FileModel" +
               " where VerbModel.FileId=FileModel.Id";             
            Pages.Items = await db.QueryGetEntityList<VerbModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
