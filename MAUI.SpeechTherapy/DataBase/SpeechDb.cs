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

          //  Database = new SQLiteAsyncConnection(StaticValues.DatabasePath, StaticValues.Flags);
        }
    }
}
