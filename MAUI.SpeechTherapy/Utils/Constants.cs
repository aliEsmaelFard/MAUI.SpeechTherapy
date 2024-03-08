using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.SpeechTherapy.Utils
{
    public class Constants
    {
        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
         DatabaseFilename);

        public const string DatabaseFilename = "SpeechDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
           // open the database in read/write mode
           SQLite.SQLiteOpenFlags.ReadWrite |
           // create the database if it doesn't exist
           SQLite.SQLiteOpenFlags.Create |
           // enable multi-threaded database access
           SQLite.SQLiteOpenFlags.SharedCache;


    }
}
