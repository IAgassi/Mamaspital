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

        public static List<Employee> getEmployees()
        {
            SQLiteConnection con = DBAccess.CreateConnection();
            string sql = "select * from Employees";
            List<Employee> EmployeeList = new List<Employee>();
            var cmd = new SQLiteCommand(sql, con);
            try
            {
                using SQLiteDataReader cur = cmd.ExecuteReader();
                while (cur.Read())
                {
                    var id = cur.GetString(0);
                    var name = cur.GetString(1);
                    var hours = cur.GetInt32(2);
                    var role_id = cur.GetInt32(3);
                    Employee emp = new Employee(name, hours, id, GetSpecificRole(role_id, con));
                    EmployeeList.Add(emp);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return EmployeeList;
        }

        public static Role GetSpecificRole(int role_id, SQLiteConnection con)
        {
            string sql = "select * from roles where Role_ID = " + role_id;
            var cmd = new SQLiteCommand(sql, con);
            try
            {
                using SQLiteDataReader cur = cmd.ExecuteReader();
                while (cur.Read())
                {
                    string role_name = cur.GetString(1);
                    string job_type = cur.GetString(2);
                    float risk = cur.GetFloat(3);
                    //todo: add ranks!
                    return new Role(role_name, job_type, risk);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}

