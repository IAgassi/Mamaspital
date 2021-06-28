using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Rank
    {
        public string RankName { get; }
        public double ExpansionRate { get; }
        public int FixedHours { get; }
        public int PaymentHours { get; }

        public Rank(string RankName, double ExpansionRate, int FixedHours, int PaymentHours = 0)
        {
            this.RankName = RankName;
            this.ExpansionRate = ExpansionRate;
            this.FixedHours = FixedHours;
            this.PaymentHours = PaymentHours;
        }

        public double GetBonuses(double Wage, int WorkHours)
        {
            double BonusMoney = 0;
            Wage *= this.ExpansionRate;
            if(WorkHours > this.FixedHours && this.FixedHours > 0)
            {
                BonusMoney += this.PaymentHours * Wage;
            }
            else
            {
                BonusMoney += WorkHours * Wage;
            }
            return BonusMoney;
        }
    }
}
