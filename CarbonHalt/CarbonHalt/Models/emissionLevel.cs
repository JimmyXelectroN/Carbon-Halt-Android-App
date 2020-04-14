using System;
using SQLite;
namespace CarbonHalt.Models
{
    public class emissionLevel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TimeRecorded { get; set; }
        public int Co2 { get; set; }
    }
}
