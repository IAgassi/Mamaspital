using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Employee
    {
        public string ID { get; }
        public string Name { get;}
        public int WorkHours { get; set; }

        public Employee(string Name, int WorkHours, string ID = "sheesh")
        {
            this.Name = Name;
            this.WorkHours = WorkHours;
            if (ID == "sheesh")
            {
                this.ID = Guid.NewGuid().ToString();
            }
            else
            {
                this.ID = ID;
            }
        }
    }
}
