using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;

namespace MAUI.SpeechTherapy.Services.Alphba
{
    public class AlphbaWordService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<AlphbaWordModel>> GetAllAsync(int AlphbaId,int Position)
        {
            GenericPageByPage<AlphbaWordModel> wordDto = new GenericPageByPage<AlphbaWordModel>();
            string query = "Select Id,Word,Type,AlphbaId" +
                " From AlphbaWordModel" +
                " where AlphbaId="+AlphbaId+" and Type="+Position;

            wordDto.Items = await db.QueryGetEntityList<AlphbaWordModel>(query);
            wordDto.RowCount = wordDto.Items.Count;
            return wordDto;
        }
    }
}
