using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Role
    {
        public string RoleName;
        public string RoleType;
        public double Risk;
        public List <Rank> Ranks;

        public Role(string JobName, string JobType,  double Risk, List <Rank> Ranks)
        {
            this.RoleType = JobType;
            this.RoleName = JobName;
            this.Risk = Risk;
            this.Ranks = Ranks;
        }

        public double CalcSalary(int WorkHours)
        {
            double Wage = 35.2;
            double salary = 0;
            for (int i = 0; i < Ranks.Count; i++)
            {
                Rank CurrentRank = Ranks[i];
                salary += CurrentRank.GetBonuses(Wage, WorkHours);
            }
            if(this.Risk > 0)
            {
                salary += (this.Risk + 1) * Wage * WorkHours;
            }
            return salary;
        }

    }
}
