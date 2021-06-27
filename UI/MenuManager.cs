﻿using System;
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
            Console.WriteLine("2 - Add new Employee");
            Console.WriteLine("3 - Add new Job");
            Console.WriteLine("4 - Add new Rank");
            Console.WriteLine("5 - Calculate Employee Salary");
            Console.WriteLine("0 - Exit System");

            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    BLManager.DisplayAll(employees);
                    break;

                case "2":
                    Console.WriteLine("Launching missiles...");
                    break;

                case "3":
                    Console.WriteLine("Displying Missile Storage...");
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
    }
}