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
   public class CalculationDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<CalculationDatabase> Instance = new AsyncLazy<CalculationDatabase>(async () =>
        {
            var instance = new CalculationDatabase();
            CreateTableResult result = await Database.CreateTableAsync<CalculationModel>();
            return instance;
        });

        public CalculationDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }


        public Task<List<CalculationModel>> GetItemsAsync()
        {
            return  Database.Table<CalculationModel>().ToListAsync();
        }

        public Task<List<CalculationModel>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<CalculationModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<CalculationModel> GetItemAsync(int id)
        {
            return Database.Table<CalculationModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CalculationModel item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(CalculationModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
