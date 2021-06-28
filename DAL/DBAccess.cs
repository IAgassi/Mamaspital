using System;
using System.Data.SQLite;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Mamaspital.Common;

namespace Mamaspital.DAL
{
    class DBAccess
    {
        public static SQLiteConnection CreateConnection()
        {
            string cs = @"URI=file:C:\Users\Ido\source\repos\Mamaspital\DAL\mamaspital.db";
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

        public static List<Employee> getEmployees()
        {
            SQLiteConnection con = DBAccess.CreateConnection();
            string sql = "select * from employees";
            //SQLiteCommand cmd = new SQLiteCommand("delete from employees", sqlite_conn);
            List<Employee> l1 = new List<Employee>();
            using var cmd = new SQLiteCommand(sql, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
                var id = rdr.GetString(0);
                var name = rdr.GetString(1);
                var hours = rdr.GetInt32(2);
                l1.Add(new Employee(name, hours, id));
            }
            con.Close();
            return l1;
        }
    }
}

