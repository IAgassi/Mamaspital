using System;
using System.Data.SQLite;
using System.Linq;
using Mamaspital.DAL;



namespace Mamaspital
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection con = DBAccess.CreateConnection();
            string sql = "select * from employees";
            //SQLiteCommand cmd = new SQLiteCommand("delete from employees", sqlite_conn);
            using var cmd = new SQLiteCommand(sql, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
            }
        }
    }
}
