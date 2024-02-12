using MAUI.SpeechTherapy.Models.Alphba;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.SpeechTherapy.DataBase
{
    public class SpeechDb
    {
        SQLiteAsyncConnection Database;
        
        async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection("");

            await Database.CreateTableAsync<AlphbaModel>();
            //  Database = new SQLiteAsyncConnection(StaticValues.DatabasePath, StaticValues.Flags);
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
        //Read one row By Field
        public async Task<List<T>> GetEntityByField<T>(string FieldName, string FieldValue) where T : class, new()
        {
            try
            {
                await Init();

                var tblName = typeof(T).Name;

                return await Database.QueryAsync<T>($"SELECT * FROM {tblName} WHERE {FieldName} = {FieldValue}");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return null;
        }

        //Read List of Entity
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
                return await Database.QueryAsync<T>(query);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return null;
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
