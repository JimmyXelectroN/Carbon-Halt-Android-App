﻿using System.Threading.Tasks;
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

        }

        public Task<List<emissionLevel>> GetEmissionLevels()
        {
            return _database.Table<emissionLevel>().ToListAsync();
        }

        public Task<int> SaveEmissionLevelAsync(emissionLevel el)
        {

            if (el.ID != 0)
            {
                return _database.UpdateAsync(el);
            }
            else {
                return _database.InsertAsync(el);
                /*
                if (!(_database.Table<emissionLevel>().FirstOrDefaultAsync().Result.TimeRecorded.Equals(el.TimeRecorded)
               && _database.Table<emissionLevel>().FirstOrDefaultAsync().Result.Co2 == el.Co2))
                {
                    return _database.InsertAsync(el);
                }
                else
                {
                    return _database.InsertAsync(el);
                }*/
            }
        }

    }
}
