using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;

namespace Personal.Persistence
{
    public class InMemoryEmployeeSet : InMemoryDbSet<Employee>
    {
        public override Employee Find(params object[] keyValues)
            {
                return this.SingleOrDefault(e => e.EmployeeId == (int)keyValues.Single());
            }
    }
}
