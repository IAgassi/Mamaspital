using Mamaspital.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.BL
{
    class BLManager
    {
        public static void DisplayAll(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Name: " + employees[i].Name);
                Console.WriteLine("ID: " + employees[i].ID);
                Console.WriteLine("--------------------------");
            }
        }

        public static List<Employee> Initalize() 
        {
            return DAL.DBAccess.getEmployees();
        }
    }
}
