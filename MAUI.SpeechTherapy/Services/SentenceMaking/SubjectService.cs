using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.SentenceMaking;

namespace MAUI.SpeechTherapy.Services.SentenceMaking
{
    public class SubjectService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<SubjectModel>> GetPageByPage(int PageSize, int PageNumber)
        {
            GenericPageByPage<SubjectModel> Pages = new GenericPageByPage<SubjectModel>();
            string query = "Select SubjectModel.Id,Name,Data,FileType" +
               " From SubjectModel,FileModel" +
               " where SubjectModel.FileId=FileModel.Id" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From SubjectModel";
            Pages.Items = await db.QueryGetEntityList<SubjectModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        public async Task<GenericPageByPage<SubjectModel>> GetPageByPage()
        {
            GenericPageByPage<SubjectModel> Pages = new GenericPageByPage<SubjectModel>();
            string query = "Select SubjectModel.Id,Name,Data,FileType" +
               " From SubjectModel,FileModel" +
               " where SubjectModel.FileId=FileModel.Id";
            Pages.Items = await db.QueryGetEntityList<SubjectModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
