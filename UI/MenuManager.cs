using System;
using System.Collections.Generic;
using System.Text;
using Mamaspital.Common;
using Mamaspital.BL;

namespace Mamaspital.UI
{
    class MenuManager
    {
        public static void Menu(List<Employee> employees)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Display all Employees");
            Console.WriteLine("2 - Clock in");
            Console.WriteLine("3 - Calculate Employee Salary");
            Console.WriteLine("0 - Exit System");

            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    BLManager.DisplayAll(employees);
                    break;

                case "2":
                    AddHours(employees);
                   
                    break;

                case "3":
                    SalaryCalculation(employees);
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Bad Input, please follow the given instructions!");
                    Console.WriteLine();
                    break;
            }
            Menu(employees);
        }

        public static void AddHours(List<Employee> employees)
        {
            Console.WriteLine("Enter the ID of the employee");
            var dude = BLManager.FindEmployeeByID(employees, Console.ReadLine());
            if (dude != null)
            {
                Console.WriteLine("How many hours did this employee work this month?");
                string input = Console.ReadLine();
                int number;
                if (Int32.TryParse(input, out number))
                {
                    dude.SetWorkHours(number);
                }
                else
                {
                    Console.WriteLine("that's not a number dumbass!");
                    AddHours(employees);
                }
            }
            else
            {
                Console.WriteLine("Employee not found!");
                AddHours(employees);
            }
        }

        public static void SalaryCalculation(List<Employee> employees)
        {
            Console.WriteLine("Enter the ID of the employee");
            var dude = BLManager.FindEmployeeByID(employees, Console.ReadLine());
            if (dude != null)
            {
                var salary = dude.getSalary();
                Console.WriteLine("{0}'s monthly salary is: {1} NIS!", dude.Name, salary);
            }
            else
            {
                Console.WriteLine("Employee not found!");
                SalaryCalculation(employees);
            }
        }

    }
}
