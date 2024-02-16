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
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
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
