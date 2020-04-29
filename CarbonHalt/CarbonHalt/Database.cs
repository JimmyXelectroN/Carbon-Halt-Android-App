using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using CarbonHalt.Models;

namespace CarbonHalt
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath) 
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<emissionLevel>().Wait();
            _database.CreateTableAsync<hint>().Wait();

        }

        public Task<List<emissionLevel>> GetEmissionLevels()
        {
            return _database.Table<emissionLevel>().ToListAsync();
        }

        public Task<List<hint>> GetHints() 
        {
            return _database.Table<hint>().ToListAsync();
        }

        public void ClearHints()
        {
            _database.ExecuteAsync("DELETE FROM hint");
        }

        public Task<int> SaveHintAsync(hint h) 
        {
            return _database.InsertAsync(h);
        }

        public bool hintIsEmpty() {
            if (_database.Table<hint>().FirstOrDefaultAsync().Result == null) {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Task<int> SaveEmissionLevelAsync(emissionLevel el)
        {

            if (el.ID != 0)
            {
                return _database.UpdateAsync(el);
            }
            else {
                return _database.InsertAsync(el);
            }
        }

    }
}
