using System;
using System.Collections.Generic;
using System.Text;

namespace Mamaspital.Common
{
    class Role
    {
        public string RoleName;
        public string RoleType;
        public float Risk;
        public List <Rank> Ranks;

        //todo: add ranksssss , List<Rank> ranks
        public Role(string JobName, string JobType,  float Risk)
        {
            this.RoleType = JobType;
            this.RoleName = JobName;
            this.Risk = Risk;
            //this.Ranks = ranks;
        }

    }
}
