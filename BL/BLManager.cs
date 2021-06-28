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
                Console.WriteLine("Work Hours: " + employees[i].WorkHours);
                Console.WriteLine("--------------------------");
            }
        }

        public static List<Employee> Initalize()
        {
            return DAL.DBAccess.getEmployees();
        }

        public static Employee FindEmployeeByID(List<Employee> employees, string id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if(employees[i].ID == id)
                {
                    return employees[i];
                }
            }
            return null;
        }

    }
}
