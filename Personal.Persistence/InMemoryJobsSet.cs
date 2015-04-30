using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;

namespace Personal.Persistence
{
    public class InMemoryJobsSet : InMemoryDbSet<Job>
    {
            public override Job Find(params object[] keyValues)
            {
                return this.SingleOrDefault(e => e.JobId == (string)keyValues.Single());
            }
    }
}
