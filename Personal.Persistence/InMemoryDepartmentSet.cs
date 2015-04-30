using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;

namespace Personal.Persistence
{
    public class InMemoryDepartmentSet : InMemoryDbSet<Department>
    {
        public override Department Find(params object[] keyValues)
            {
                return this.SingleOrDefault(e => e.DepartmentId == (int)keyValues.Single());
            }
    }
}
