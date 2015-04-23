using System.Linq;
using Personal.Entities;
using Personal.Persistence;
using Shouldly;

namespace Personal.Tests
{
    public class InMemoryHrContextTests
    {
        public void CanAddAndRetrieveJob()
        {
            IHrContext context = new InMemoryHrContext();

            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Chief Executive Officer",
                MinSalary = 1,
                MaxSalary = int.MaxValue
            };
            context.Jobs.Add(job);

            context.SaveChanges();

            var retrievedJob = context.Jobs.Single(j => j.JobId == "CEO");
            retrievedJob.ShouldBe(job);
        }
    }
}
