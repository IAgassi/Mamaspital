using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Employee
    {
        public Guid ID { get; }
        public string Name { get;}
        public DateTime DateOfBirth { get;}
        public DateTime EmploymentDate { get;}
        public int WorkHours { get; set; }

        public Employee(string Name, DateTime DateOfBirth, DateTime EmploymentDate, int WorkHours)        
        {
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.EmploymentDate = EmploymentDate;
            this.WorkHours = WorkHours;
            this.ID = new Guid();
        }
    }
}
