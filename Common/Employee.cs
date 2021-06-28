using System;
using System.Collections.Generic;
using System.Text;
using Mamaspital.Common;

namespace Mamaspital.Common
{
    class Employee
    {
        public string ID { get; }
        public string Name { get;}
        public int WorkHours { get; set; }
        public Role Role { get; }

        public Employee(string Name, int WorkHours, string ID = "none", Role Role = null)
        {
            this.Name = Name;
            this.WorkHours = WorkHours;
            this.Role = Role;
            if (ID == "none")
            {
                this.ID = Guid.NewGuid().ToString();
            }
            else
            {
                this.ID = ID;
            }
        }

        public void SetWorkHours(int hours)
        {
            WorkHours = hours;
            string sql = String.Format("UPDATE Employees SET Work_Hours = {0} WHERE Employee_ID = '{1}'", 
                this.WorkHours, this.ID);
            DAL.DBAccess.UpdateTable(sql);
        }

        public double getSalary()
        {
            return Role.CalcSalary(this.WorkHours);
        }
    }
}
