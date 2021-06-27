using System;
using System.Data.SQLite;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.DAL
{
    class DBAccess
    {
        public static SQLiteConnection CreateConnection()
        {
            string cs = @"URI=file:C:\Users\idoag\source\repos\Mamaspital\DAL\mamaspital.db";
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(cs);
            // Open the connection:
            try
            {
                sqlite_conn.Open();
                Console.WriteLine("Database Connection Successful!");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured connecting to database, jackass");
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }

        public static void getEmployees()
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

