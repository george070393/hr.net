using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using AutoMapper;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controller
{
    public class JobsController : ApiController
    {
        
            private readonly IHrContext context;

            public JobsController(IHrContext context)
            {
                this.context = context;
            
            }

        // GET: api/Jobs
        public IEnumerable<Job> Get()
        {
            return context.Jobs;
        }

        // GET: api/Jobs/5
        public IHttpActionResult Get(string id)
        {
            var jobDB = context.Jobs.Find(id);
            if (jobDB != null)
            {
                return Ok(jobDB);
            }
            return NotFound();
        }

        // POST: api/Jobs
        public IHttpActionResult Post(Job job)
        {
            var addedjob = context.Jobs.Add(job);

            return CreatedAtRoute("DefaultApi",new {controller="Jobs",id=addedjob.JobId},addedjob);

        }

        // PUT: api/Jobs/5
        public IHttpActionResult Put(Job job)
        {
            if (ModelState.IsValid)
            {


                var dbjob = context.Jobs.Find(job.JobId);
                if (dbjob != null)
                {
                    Mapper.Map(job, dbjob);

                    return Ok(context.SaveChanges());
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Jobs/{id}/{newMaxSalary}")]
        [Authorize(Roles = "Admin,Sef")]
        public IHttpActionResult ModifyMaxSalary(string id, int newMaxSalary)
        {
            var dbjob = context.Jobs.Find(id);
            if (dbjob != null)
            {
                dbjob.MaxSalary = newMaxSalary;
                return Ok(context.SaveChanges());
            }
            return BadRequest();
            
        }

        // DELETE: api/Jobs/5
        public IHttpActionResult Delete(string id)
        {
            var dbjob = context.Jobs.Find(id);
            if(dbjob != null)
            {
                return Ok(context.Jobs.Remove(dbjob));
            }
            return NotFound();
        }
    }
}
