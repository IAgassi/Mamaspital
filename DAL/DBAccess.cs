using System;
using System.Data.SQLite;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Mamaspital.Common;
using System.Runtime.InteropServices;
using System.IO;

namespace Mamaspital.DAL
{
    class DBAccess
    {
        public static SQLiteConnection CreateConnection()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            string cs = @"data source = mamaspital.db";
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection(cs);
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
            catch (Exception e)
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
                    var ranks = GetRoleRanks(role_id, con);
                    return new Role(role_name, job_type, risk, ranks);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static List<Rank> GetRoleRanks(int role_id, SQLiteConnection con)
        {
            string sql = "select * from Role_To_Ranks where Role_FK = " + role_id;
            var cmd = new SQLiteCommand(sql, con);
            List<int> RankIDs = new List<int>();
            try
            {
                using SQLiteDataReader cur = cmd.ExecuteReader();
                while (cur.Read())
                {
                    RankIDs.Add(cur.GetInt32(1));
                }
                List<Rank> Ranks = new List<Rank>();
                for(int i=0; i<RankIDs.Count; i++)
                {
                    int CurrentRank = RankIDs[i];
                    Ranks.Add(GetSpecificRank(CurrentRank, con));
                }
                return Ranks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("fuck");
            return null;
        }

        public static Rank GetSpecificRank(int rank_id, SQLiteConnection con)
        {
            string sql = "select * from Ranks where Rank_ID = " + rank_id;
            var cmd = new SQLiteCommand(sql, con);
            List<int> RankIDs = new List<int>();
            try
            {
                using SQLiteDataReader cur = cmd.ExecuteReader();
                while (cur.Read())
                {
                    string rank_name = cur.GetString(1);
                    float expansion_rate = cur.GetFloat(2);
                    int mandatory_hours = cur.GetInt32(3);
                    int payment_hours = cur.GetInt32(4);
                    return new Rank(rank_name, expansion_rate, mandatory_hours, payment_hours);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("fuck2");
            return null;
        }

        public static void UpdateTable(string sql)
        {
            Console.WriteLine("Querying: " +sql);
            using var cmd = new SQLiteCommand(sql, CreateConnection());
            cmd.ExecuteNonQuery();
        }
    }
}

