using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Employee
    {
        private Guid ID { get; }
        private string Name { get; }
        private DateTime DateOfBirth { get; }
        private DateTime EmploymentDate { get; }
        private int WorkHours { get; }

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
