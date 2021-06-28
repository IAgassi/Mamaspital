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

        public void setWorkHours(int hours)
        {
            this.WorkHours = hours;
        }
    }
}
