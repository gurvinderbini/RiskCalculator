using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DB
{
   public class DatabaseService
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<CalculationDatabase> Instance = new AsyncLazy<CalculationDatabase>(async () =>
        {
            var instance = new CalculationDatabase();
            CreateTableResult result = await Database.CreateTableAsync<CalculationModel>();
            return instance;
        });

        public DatabaseService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
    }
 
}
