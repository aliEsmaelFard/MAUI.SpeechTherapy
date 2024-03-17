using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Models.Concept;
using MAUI.SpeechTherapy.Models.File;
using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Models.SentenceMaking;
using MAUI.SpeechTherapy.Utils;
using SQLite;

namespace MAUI.SpeechTherapy.DataBase
{
    public class SpeechDb
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constants.DbPath, Constants.Flags);

            await Database.CreateTableAsync<AlphbaBookModel>();
            await Database.CreateTableAsync<AlphbaModel>();
            await Database.CreateTableAsync<AlphbaWordModel>();

            await Database.CreateTableAsync<FileModel>();

            await Database.CreateTableAsync<FlashCardCategory>();
            await Database.CreateTableAsync<FlashCardModel>();

            await Database.CreateTableAsync<QuestionModel>();
            await Database.CreateTableAsync<QuestionCategoryModel>();

            await Database.CreateTableAsync<SentenceMakingModel>();
            await Database.CreateTableAsync<ObjectModel>();
            await Database.CreateTableAsync<VerbModel>();
            await Database.CreateTableAsync<SubjectModel>();

            await Database.CreateTableAsync<ConceptCategoryQuestionModel>();
            await Database.CreateTableAsync<ConceptCategorySentenceModel>();
            await Database.CreateTableAsync<ConceptQuestionModel>();
            await Database.CreateTableAsync<ConceptSentenceModel>();
        }

        public async Task<List<T>> GetEntityList<T>() where T : new()
        {
            try
            {
                await Init();
                return await Database.Table<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return null;
        }

        //Read one row By Id
        public async Task<T> GetEntityById<T>(int EntityID) where T : class, new()
        {
            try
            {
                await Init();

                var tblName = typeof(T).Name;

                return await Database.FindWithQueryAsync<T>($"SELECT * FROM {tblName} WHERE Id = {EntityID}");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return default(T);
        }

        //Query That Return List Of Entity
        public async Task<List<T>> QueryGetEntityList<T>(string query) where T : new()
         {
            try
            {
                await Init();
                return await  Database.QueryAsync<T>(query);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return null;
        }
        public async Task<int> GetCount(string query)
        {
            try
            {
                await Init();
                 

                return await Database.ExecuteScalarAsync<int>(query);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return 0;
        }
       
        //Query That Return One Entity
        public async Task<T> QueryGetEntity<T>(string query) where T : new()
        {
            try
            {
                await Init();
                return await Database.FindWithQueryAsync<T>(query);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return default(T?);
        }

        //Run Custom Query
        public async Task QueryCustom<T>(string query) where T : new()
        {
            try
            {
                await Init();
                await Database.QueryAsync<T>(query);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
