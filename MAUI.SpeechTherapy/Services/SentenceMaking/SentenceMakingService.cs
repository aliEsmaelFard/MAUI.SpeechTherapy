using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.SentenceMaking;

namespace MAUI.SpeechTherapy.Services.SentenceMaking
{
    public class SentenceMakingService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<SentenceMakingModel>> GetPageByPage(int PageSize, int PageNumber)
        {
            GenericPageByPage<SentenceMakingModel> Pages = new GenericPageByPage<SentenceMakingModel>();
            string query = "Select SentenceMakingModel.Id,SubjectId,ObjectId,VerbId," +
                "(Select FileModel.Data from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=VerbModel.FileId) as VerbData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=VerbModel.FileId) as VerbFileType" +
                " From SentenceMakingModel,SubjectModel,ObjectModel,VerbModel" +
                " where  SentenceMakingModel.SubjectId=SubjectModel.Id" +
                " And SentenceMakingModel.ObjectId=ObjectModel.Id" +
                " And SentenceMakingModel.VerbId =VerbModel.Id" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From SentenceMakingModel";
            Pages.Items = await db.QueryGetEntityList<SentenceMakingModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        public async Task<GenericPageByPage<SentenceMakingModel>> GetPageByPage()
        {
            GenericPageByPage<SentenceMakingModel> Pages = new GenericPageByPage<SentenceMakingModel>();
            string query = "Select SentenceMakingModel.Id,SubjectId,ObjectId,VerbId," +
                "(Select FileModel.Data from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=VerbModel.FileId) as VerbData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=VerbModel.FileId) as VerbFileType" +
                " From SentenceMakingModel,SubjectModel,ObjectModel,VerbModel" +
                " where  SentenceMakingModel.SubjectId=SubjectModel.Id" +
                " And SentenceMakingModel.ObjectId=ObjectModel.Id" +
                " And SentenceMakingModel.VerbId =VerbModel.Id" ;
            Pages.Items = await db.QueryGetEntityList<SentenceMakingModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
