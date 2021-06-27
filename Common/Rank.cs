using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Rank
    {
        private string RankName;
        private int ExpansionRate;
        private int FixedHours;
        private int Risk;

        public Rank( string RankName, int ExpansionRate, int FixedHours, int Risk)
        {
            this.RankName = RankName;
            this.ExpansionRate = ExpansionRate;
            this.FixedHours = FixedHours;
            this.Risk = Risk;
        }
    }
}
