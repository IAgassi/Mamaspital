using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Role
    {
        private string JobType;
        private string JobName;
        private int HourlyRate;
        private List <Rank> Ranks;


        public Role(string JobType, string JobName, int HourlyRate, List<Rank> ranks)
        {
            this.JobType = JobType;
            this.JobName = JobName;
            this.HourlyRate = HourlyRate;
            this.Ranks = ranks;
        }

    }
}
