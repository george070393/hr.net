using Personal.Entities;
using Personal.Persistence;
using System.Collections.Generic;
using System.Web.Http;

namespace Personal.WebApi
{
    public class JobsController : ApiController
    {
        private readonly InMemoryHrContext context;
        public JobsController(InMemoryHrContext ctx)
        {
            context = ctx;
        }
        // GET api/<controller>
        public IEnumerable<Job> Get()
        {
            return context.Jobs;
        }

        // GET api/<controller>/5
        public Job Get(string id)
        {
            return context.Jobs.Find(id);
            
        }

        // POST api/<controller>
        public int Post(Job job)
        {
            context.Jobs.Add(job);
            return context.SaveChanges();
        }

        // PUT api/<controller>/5
        public Job Put(string id, Job job)
        {
            var jobDb = context.Jobs.Find(id);
            if (jobDb != null)
            {
                jobDb.JobTitle = job.JobTitle;
                jobDb.MaxSalary = job.MaxSalary;
                jobDb.MinSalary = job.MinSalary;
            }
            context.SaveChanges();
            return job;
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            var job = context.Jobs.Find(id);
            context.Jobs.Remove(job);
            context.SaveChanges();
        }
    }
}