using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;

namespace MAUI.SpeechTherapy.Services.Alphba
{
    public class AlphbaService
    {
        SpeechDb db=new SpeechDb();
        public async Task<GenericPageByPage<AlphbaModel>> GetAllAsync()
        {
            GenericPageByPage<AlphbaModel> alphba = new GenericPageByPage<AlphbaModel>();
            //string query = "Select Id,Name,FileId,Data,FileType" +queryCount+
            //    " From AlphbaModel,FileModel" +
            //    " where AlphbaModel.FileId=FileModel.Id";
            //string query = "Select Id,Name,FileId From AlphbaModel";

            alphba.Items= await db.GetEntityList<AlphbaModel>();
            alphba.RowCount = alphba.Items.Count;
            return alphba;
        }
    }
}
