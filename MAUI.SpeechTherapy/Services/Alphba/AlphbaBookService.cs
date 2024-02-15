using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;

namespace MAUI.SpeechTherapy.Services.Alphba
{
    public class AlphbaBookService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<AlphbaBookModel>> GetPageByPage(int PageSize,int PageNumber,int AlphbaId)
        {
            GenericPageByPage<AlphbaBookModel> Book = new GenericPageByPage<AlphbaBookModel>();
            string query = "Select AlphbaBookModel.Id,Text,Data,FileType" +
                " From AlphbaBookModel,FileModel" +
                " where AlphbaBookModel.FileId=FileModel.Id" +
                " and AlphbaId=" + AlphbaId + " LIMIT " + PageSize+ " OFFSET "+(PageNumber-1);
            string queryCount = "Select Count(Id) From AlphbaBookModel where AlphbaId=" + AlphbaId;
            Book.Items = await db.QueryGetEntityList<AlphbaBookModel>(query);
            Book.RowCount = await db.GetCount(queryCount);
            return Book;
        }
    }
}
