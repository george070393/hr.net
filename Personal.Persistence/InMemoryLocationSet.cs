using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;

namespace Personal.Persistence
{
    public class InMemoryLocationSet : InMemoryDbSet<Location>
    {
        public override Location Find(params object[] keyValues)
            {
                return this.SingleOrDefault(e => e.LocationId == (int)keyValues.Single());
            }
    }
}
